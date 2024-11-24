using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBoss : Agent
{
    [SerializeField] private StateListSO _states;
    [SerializeField] private AnimParamSO _patternNumber;
    public float patternTime;

    public AgentRenderer AgentRenderer { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        AgentRenderer = GetComponent<AgentRenderer>();
        stateMachine = new StateMachine(_states, this);
        stateMachine.Initialize(FSMState.Idle);
    }

    public void Update()
    {
        //StateMachine.CurrentState.UpdateState();
        stateMachine.UpdateStateMachine();

    }
}
