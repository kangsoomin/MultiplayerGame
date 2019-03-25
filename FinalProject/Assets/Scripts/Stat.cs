using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    //아마 float으로 수정해야할 거다. 가방공간말고 데미지나 아머, 핏스피드는 float이 적절하기 때문
    [SerializeField]
    private int baseValue;

    public int GetValue()
    {
        int finalValue = baseValue + modifier;
        //modifiers.ForEach(x => finalValue += x);
        Debug.Log(finalValue);
        return finalValue;
    }

    private int modifier = 0;

    //private List<int> modifiers = new List<int>();

    public void AddModifier(int value)
    {
        modifier += value;
        //Mathf.Clamp함수를 써야될수도있음
    }

    public void RemoveModifier(int value)
    {
        modifier -= value;
        //Mathf.Clamp함수를 써야될수도있음
    }

    /*
    public void AddModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
    */


}
