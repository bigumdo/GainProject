using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBoss : Agent
{
    [SerializeField] private StateListSO _states;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine(_states, this);
    }
}
