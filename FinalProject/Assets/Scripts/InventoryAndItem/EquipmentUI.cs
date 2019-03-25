using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    EquipmentManager equipManager;

    public InventorySlot[] equipSlots;

    void Start()
    {
        equipManager = EquipmentManager.instance;
        equipManager.onEquipmentChanged += UpdateEquipUI;
        equipSlots = gameObject.GetComponentsInChildren<InventorySlot>();
    }

 
    void UpdateEquipUI(Equipment newItem, Equipment oldItem)
    {
        int typeIndex = (int)newItem.equipmentType;
        switch(typeIndex)
        {
            case 0:
                {
                    equipSlots[0].ClearSlot();
                    if(newItem != null)
                    {
                        equipSlots[0].AddItem(newItem);
                    }
                    
                    break;
                }
            case 1:
                {
                    equipSlots[1].ClearSlot();
                    if (newItem != null)
                    {
                        equipSlots[1].AddItem(newItem);
                    }
                    break;
                }
            case 2:
                {

                    //가방에 해당하는 부분이다.
                    equipSlots[2].ClearSlot();
                    if (newItem != null)
                    {
                        equipSlots[2].AddItem(newItem);
                    }
                    break;
                }
            case 3:
                {
                    equipSlots[3].ClearSlot();
                    if (newItem != null)
                    {
                        equipSlots[3].AddItem(newItem);
                    }
                    break;
                }

        }
    }
}
