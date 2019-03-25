using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;
    InventorySlot[] eSlots;
    InventorySlot[] sSlots;
    InventorySlot[] tSlots;
    public GameObject slotsE;
    public GameObject slotsS;
    public GameObject slotsT;

    void Start()
    {
        inventory = Inventory.instance;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
        eSlots = slotsE.GetComponentsInChildren<InventorySlot>();
        sSlots = slotsS.GetComponentsInChildren<InventorySlot>();
        tSlots = slotsT.GetComponentsInChildren<InventorySlot>();
        
        inventory.onItemChangedCallback += UpdateUI;
        inventory.onItemChangedCallback += UpdateTUI;
        inventory.onItemChangedCallback += UpdateEUI;
        inventory.onItemChangedCallback += UpdateSUI;
        UpdateUI();
       
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

    }

    void UpdateUI()
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.otherItems.Count)  // If there is an item to add
            {
                slots[i].AddItem(inventory.otherItems[i]);   // Add it
            }
            else if(i >= inventory.otherItems.Count && i < inventory.space)
            {
                // Otherwise clear the slot
                slots[i].ClearSlot();
            }
            else
            {
                slots[i].UnEnableSlot();
            }
        }
    }
    void UpdateEUI()
    {
        
        for (int i = 0; i < eSlots.Length; i++)
        {
            if(i < inventory.enforcementItems.Count)
            {
                eSlots[i].AddItem(inventory.enforcementItems[i]);
            }
            else
            {
                eSlots[i].ClearSlot();
            }
        }
    }
    void UpdateSUI()
    {
        for (int i = 0; i < sSlots.Length; i++)
        {
            if (i < inventory.specialItems.Count)
            {
                sSlots[i].AddItem(inventory.specialItems[i]);
            }
            else
            {
                sSlots[i].ClearSlot();
            }
        }
    }
    void UpdateTUI()
    {
        for (int i = 0; i < tSlots.Length; i++)
        {
            if (i < inventory.throwingItems.Count)
            {
                tSlots[i].AddItem(inventory.throwingItems[i]);
            }
            else
            {
                tSlots[i].ClearSlot();
            }
        }
    }
}
