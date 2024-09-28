using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] private int _baseValue;

    public List<int> statList;
    public bool isPersent;

    public int GetValue()
    {
        int value = _baseValue;
        foreach(int v in statList)
        {
            value += v;
        }
        return value;
    }

    public void AddValue(int value)
    {
        if(value != 0)
            statList.Add(value);
    }

    public void RemoveValue(int value)
    {
        if(value != 0)
            statList.RemoveAt(value);
    }

    public void SetDefalutValue(int value)
    {
        _baseValue = value;
    }

}
