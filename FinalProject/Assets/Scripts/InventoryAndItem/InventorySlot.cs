using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //other 인벤토리의 경우 우클릭을 하면 아이템을 버리거나 하는 함수를 만들어
    //버튼에 등록시키면 되고, 그 외 아이템은 어떻게 사용할지의 여부에 따라 함수를
    //만들어서 마찬가지로 각각의 버튼마다 고유하게 사용할만한 함수를 만들어
    //사용하면 됨.


    public Image icon;          // Reference to the Icon image
    //public Button removeButton; // Reference to the remove button
    public Sprite unEnable;
   

    Item item;  // Current item in the slot

    // Add item to the slot
    public void AddItem(Item newItem)
    {
       
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
       
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }

    public void UnEnableSlot()
    {
        
        
        item = null;
        icon.sprite = unEnable;
        icon.enabled = true;
        
    }

    // Called when the remove button is pressed
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    // Called when the item is pressed
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}