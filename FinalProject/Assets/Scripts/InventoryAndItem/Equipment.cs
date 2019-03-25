using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    
    public EquipmentType equipmentType;
   
    public int armorLevel;
   
    public int armorPercentage;
   
    public int totalValue;

    public override void Use()
    {
        base.Use();
        //밑의 에큅메쏘드가 Use를 통해 실현될 필요가 없는 듯 하다. 왜냐면 픽업하는 순간
        //바로 추가되는 것이기 때문이다.
        //EquipmentManager.instance.Equip(this);
        //Remove it from Inventory --> 내 구현사항과는 좀 다른듯..
    }

}

public enum EquipmentType { Head, Chest, Bag, Feet }
