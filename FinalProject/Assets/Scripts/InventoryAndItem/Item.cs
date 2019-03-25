using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public ItemType itemType;

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public string explain = "";


    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        //
    }

}

public enum ItemType { equipmentItem, enforcementItem, specialItem, throwingItem, otherItem }


