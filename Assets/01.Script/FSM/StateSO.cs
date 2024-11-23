using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FSMState
{
    Idle,
    Attack,
    Run,
    Dash,
    Jump,
    Fall,
    Hit,
    Die,
    Pattern
}

[CreateAssetMenu(menuName ="SO/FSM/StateSO")]
public class StateSO : ScriptableObject
{
    public FSMState StateEnum;
    public string className;
    public AnimParamSO animParam;
}
