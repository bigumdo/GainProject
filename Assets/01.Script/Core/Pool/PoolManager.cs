using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum poolingType
{
    Text
}


public class PoolManager : MonoBehaviour
{
    public PoolObject[] poolList;

    public Dictionary<poolingType, PoolObject> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<poolingType, PoolObject>();
        foreach (var p in poolList)
        {
            for(int i =0;i<p.poolCnt;++i)
            {
                Instantiate(p.poolObject,transform);
                poolDictionary.Add(p.poolType, p);
            }
        }
    }
}
