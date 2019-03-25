using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion
    //public enum ItemType { equipmentItem, enforcementItem, specialItem, throwingItem, otherItem }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //단지 따라 코딩한 것일 뿐 내 게임에 맞추어서 얼마든지 변형 가능.
    public int space = 8;

    public int abilitySpace = 2;
    public List<Item> enforcementItems = new List<Item>();
    public List<Item> specialItems = new List<Item>();
    public List<Item> throwingItems = new List<Item>();
    public List<Item> otherItems = new List<Item>();

    EquipmentManager equipManager;
    void Start()
    {
        equipManager = EquipmentManager.instance;
    }
    public bool Add(Interactable interactableItem)
    {
        bool isOK = false;
        Item newItem = interactableItem.GetComponent<ItemPickUp>().item;
        int itemType = (int)newItem.itemType;
        switch (itemType)
        {
            case 0:
                {

                    equipManager.Equip(interactableItem);
                    Debug.Log("HIHI");
                    //EquipmentManager를 통해 이큅 가능한가 여부를 체크하면 될 듯.
                    break;
                }
            case 1:
                {
                    if (enforcementItems.Count >= abilitySpace)
                    {
                        Debug.Log("Not Enough room for enforcementItems");
                        return isOK;
                    }
                    enforcementItems.Add(newItem);
                    break;
                }
            case 2:
                {
                    if (specialItems.Count >= abilitySpace)
                    {
                        Debug.Log("Not Enough room for SpecialItems");
                        return isOK;
                    }
                    specialItems.Add(newItem);
                    break;
                }
            case 3:
                {
                    if (throwingItems.Count >= abilitySpace)
                    {
                        Debug.Log("Not Enough room for throwingItems");
                        return isOK;
                    }
                    throwingItems.Add(newItem);
                    break;
                }
            default:
                {
                    if (otherItems.Count >= space)
                    {

                        //Log를 띄우는게 아니라 UI오브젝트로써 아이템을 추가 못한다는 글씨를 추가...
                        //물론 배그처럼 F : 아이템 줍기 이런식의 대화상자를 앞서 아이템이 탐지될 떄 띄울 것이기
                        //때문에 이 경우엔 그 글씨를 빨갛게 만드는 방법을 적용해보자..
                        Debug.Log("Not Enough room");
                        return isOK;
                    }
                  

                    otherItems.Add(newItem);


                    break;
                }
        }
        isOK = true;
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return isOK;

    }
    /*
            public bool Add(Item item)
            {
                bool isOK = false;
                int itemType = (int)item.itemType;
                switch(itemType)
                {
                    case 0:
                        {

                            equipManager.Equip((Equipment)item);
                            Debug.Log("HIHI");
                            //EquipmentManager를 통해 이큅 가능한가 여부를 체크하면 될 듯.
                            break;
                        }
                    case 1:
                        {
                            if (enforcementItems.Count >= abilitySpace)
                            {
                                Debug.Log("Not Enough room for enforcementItems");
                                return isOK;
                            }
                            enforcementItems.Add(item);
                            break;
                        }
                    case 2:
                        {
                            if (specialItems.Count >= abilitySpace)
                            {
                                Debug.Log("Not Enough room for SpecialItems");
                                return isOK;
                            }
                            specialItems.Add(item);
                            break;
                        }
                    case 3:
                        {
                            if (throwingItems.Count >= abilitySpace)
                            {
                                Debug.Log("Not Enough room for throwingItems");
                                return isOK;
                            }
                            throwingItems.Add(item);
                            break;
                        }
                    default:
                        {
                            if (otherItems.Count >= space)
                            {

                                //Log를 띄우는게 아니라 UI오브젝트로써 아이템을 추가 못한다는 글씨를 추가...
                                //물론 배그처럼 F : 아이템 줍기 이런식의 대화상자를 앞서 아이템이 탐지될 떄 띄울 것이기
                                //때문에 이 경우엔 그 글씨를 빨갛게 만드는 방법을 적용해보자..
                                Debug.Log("Not Enough room");
                                return isOK;
                            }

                            otherItems.Add(item);


                            break;
                        }

                }


            isOK = true;
    if (onItemChangedCallback != null)
    {
        onItemChangedCallback.Invoke();
    }
    return isOK;

    }
    */

    public void Remove(Item item)
    {
        //Remove역시 아이템 타입에 맞추어 따로 구현
        otherItems.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

    }

   
}
