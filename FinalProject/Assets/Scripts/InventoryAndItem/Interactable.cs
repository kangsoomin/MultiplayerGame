using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Item item;
    public float radius = 0.5f;
    //public Transform interactionTransform;

    bool isFocus = false;
    //Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if(isFocus && !hasInteracted)
        {
                Interact();
                hasInteracted = true;
        }
    }

    public void OnFocused()//Transform playerTransform)
    {
        isFocus = true;
        //player = playerTransform;
        hasInteracted = false;
    }

    /*
    public void OnDeFocused()
    {
        isFocus = false;
        //player = null;
        hasInteracted = false;
    }
    */
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
       
    }



}
