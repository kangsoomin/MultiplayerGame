using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        Inventory.instance.onItemChangedCallback += BagValueChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        //이것은 스크립트를 최대한 묘사하기 위해 따라한 것이며 추후 내
        //게임에 맞추어서 변형하는 작업이 필수적...
        

        //일단 에큅먼트 스크립트에 구현되어 있는 밸류들이 중구난방이고 통일되어있지 않아서
        //여기에 일단 메쏘드를 구현해놓는다 한들 좀 지저분해 보일 수 있다. 그래서 통일이 필요한데
        //이는 추후에 계속 구현해보면서 생각해볼 문제이다.
        if(newItem != null)
        {
            int newItemTypeIndex = (int)newItem.equipmentType;
            if(newItemTypeIndex == 0)
            {
                headArmor.AddModifier(newItem.totalValue);
            }
            else if(newItemTypeIndex == 1)
            {
                chestArmor.AddModifier(newItem.totalValue);
            }
            else if(newItemTypeIndex == 2)
            {
                bagSpace.AddModifier(newItem.totalValue);
                BagValueChanged();
            }
            else
            {
                feetSpeed.AddModifier(newItem.totalValue);
            }
            //armor.AddModifier(newItem.armorPercentage);
            //damage.AddModifier(newItem.armorLevel);
        }
        if(oldItem != null)
        {
            int oldItemTypeIndex = (int)oldItem.equipmentType;
            if (oldItemTypeIndex == 0)
            {
                headArmor.RemoveModifier(oldItem.totalValue);
            }
            else if (oldItemTypeIndex == 1)
            {
                chestArmor.RemoveModifier(oldItem.totalValue);
            }
            else if (oldItemTypeIndex == 2)
            {
                bagSpace.RemoveModifier(oldItem.totalValue);
                BagValueChanged();
            }
            else
            {
                feetSpeed.RemoveModifier(oldItem.totalValue);
            }
            //armor.RemoveModifier(oldItem.armorPercentage);
            //damage.RemoveModifier(oldItem.armorLevel);
        }
      
    }

    void BagValueChanged()
    {
       int bagValue = bagSpace.GetValue();
        Inventory.instance.space = bagValue;
    }
}
