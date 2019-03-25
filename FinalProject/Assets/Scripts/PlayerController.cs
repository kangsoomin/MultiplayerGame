using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float radius = 0.2f;

    public Interactable focusedItem;
    public LayerMask whatIsItem;

    public Collider2D[] collList;

    public RectTransform InteractUI;
    public Text InteractUIText;
    [SerializeField]
    private Item InteractItem;

    [SerializeField]
    private bool isInteracted = false;

    void Update()
    {
        
        collList = Physics2D.OverlapCircleAll(transform.position, radius, whatIsItem);
        if(collList.Length > 1)
        {
            Interactable pickableItem;
            float min = 0.5f;
            for (int i = 0; i < collList.Length; i++)
            {
                float temp = Vector2.Distance(transform.position, collList[i].transform.position);
                if (temp < min)
                {
                    min = temp;
                    pickableItem = collList[i].GetComponent<Interactable>();
                    SetFocus(pickableItem);
                }
            }
            
        
        }
        else if(collList.Length == 1)
        {
            Interactable pickableItem = collList[0].GetComponent<Interactable>();
            SetFocus(pickableItem);

        }
        else
        {
            SetDeFocus();
        }
        if(isInteracted)
        {
            //InteractUI.
            InteractUIText.text = InteractItem.name;
            InteractUI.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Inventory Add.... 여기서 인벤토리가 꽉찼거나, 주울 수 없는 아이템이라면 걸러야할듯.
                if(focusedItem != null)
                {
                    bool wasPickedUp = Inventory.instance.Add(focusedItem);
                    if (wasPickedUp)
                    {
                        focusedItem.OnFocused();
                    }
                }
               
               
               
            }
        }
        else
        {
            InteractUI.gameObject.SetActive(false);
        }

    }
    //Inventory에 Add할것.
    void SetFocus(Interactable pickedItem)
    {
        focusedItem = pickedItem;
        InteractItem = focusedItem.gameObject.GetComponent<ItemPickUp>().item;
        isInteracted = true;
    }

    void SetDeFocus()
    {
        focusedItem = null;
        InteractItem = null;
        isInteracted = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
