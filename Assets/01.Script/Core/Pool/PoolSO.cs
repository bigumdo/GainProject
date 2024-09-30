using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PoolObject
{
    public GameObject poolObject;
    public int poolCnt;
    public poolingType poolType;
}
[CreateAssetMenu(menuName ="SO/Pool")]
public class PoolSO : ScriptableObject
{
    public List<PoolObject> pool;
}
