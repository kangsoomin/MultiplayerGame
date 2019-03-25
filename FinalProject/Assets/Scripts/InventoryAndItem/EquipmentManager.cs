using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject[] currentEquipmentObj;
    Equipment[] currentEquipment;
   

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[numSlots];
        currentEquipmentObj = new GameObject[numSlots];
    }

    public void Equip(Interactable interactableEquipment)
    {
        //필드에 드랍하는 방법을 고민 이것이 해결되야 에큅먼트 체인지를 완성할수 잇음.
        //지금 올드에큅먼트와 뉴에큅먼트를 교환하는 과정이 제대로 구현이 되지 않았음
        //UI상으로의 업데이트와 내려놓는 오브젝트간의 유기적인 교환이 이루어져야만 함.
        //위에 에큅먼트 배열 뿐만 아니라 추가적으로 게임오브젝트 배열을 만들어놓았음
        // 이벤트발생시마다 이게 제대로 적용되기 위해 이 배열을 활용할 생각.
        //일단 최종적으로 현재 해당게임오브젝트의 셋액티브를 키고 끄는 방식으로 구현해놓았는데
        //이것이 과연 최종구현방식으로 적절할지.. 아니면 걍 Destroy으롤 쓰는게 나을지 고민해볼것.
        //마지막으로 Destroy를 쓰는게 낫다면 Gameobject를 새롭게 생성해서 그 오브젝트에 AddComponent를 하여
        //생성하는 방식이 나을 것 같다. GameObject 배열을 아예 쓰지않고..
        GameObject oldEquipmentObj = null;
        Equipment newEquipment = (Equipment)interactableEquipment.GetComponent<ItemPickUp>().item;
        int typeIndex = (int)newEquipment.equipmentType;
        Equipment oldEquipment = null;
        if(currentEquipment[typeIndex] != null)
        {

            oldEquipmentObj = currentEquipmentObj[typeIndex];
            oldEquipment = currentEquipment[typeIndex];
            oldEquipmentObj.transform.position = interactableEquipment.transform.position;
            oldEquipmentObj.SetActive(true);
            //Instantiate(oldEquipmentObj, oldEquipmentObj.transform.position, Quaternion.identity);
           
            //inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newEquipment, oldEquipment);
        }
        currentEquipmentObj[typeIndex] = interactableEquipment.gameObject;
        currentEquipment[typeIndex] = newEquipment;
    }

    public void UnEquip(int typeIndex)
    {
        if(currentEquipment[typeIndex] != null)
        {
            
            Equipment oldItem = currentEquipment[typeIndex];
            //inventory.Add(oldItem);
            currentEquipment[typeIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            UnEquip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }




}
