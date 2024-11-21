using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatOverride : MonoBehaviour
{
    [SerializeField] private StatSO _stat;
    [SerializeField] private bool _isOverrider;
    [SerializeField] private float _overriderValue;

    public StatOverride(StatSO stat) => _stat = stat;

    public StatSO CreateStat()
    {
        StatSO newStat = _stat.Clone() as StatSO;

        if(_isOverrider)
            newStat.BaseValue = _overriderValue;
        return newStat;


    }

}
