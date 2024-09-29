using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PoolObject
{
    public Object poolObject;
    public int poolCnt;
    public string poolName;
}

public class PoolManager : MonoBehaviour
{
    public PoolObject[] poolList;

    public Dictionary<string, PoolObject> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, PoolObject>();
        foreach (var p in poolList)
        {
            for(int i =0;i<p.poolCnt;++i)
            {
                Instantiate(p.poolObject,transform);
                poolDictionary.Add(p.poolName, p);
            }
        }
    }
}
