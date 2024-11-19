using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    [SerializeField] private StateListSO states;


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine(states,this);

    }

    private void Start()
    {
        stateMachine.Initialize(FSMState.Idle);
    }

    private void Update()
    {
        if(isDead) return;
            stateMachine.UpdateStateMachine();
    }

    public override void Die()
    {
        stateMachine.ChangeState(FSMState.Die);
    }

    public override void Attack()
    {
        DamageCasterCompo.DamageCast();
    }

    public void ChangeState(FSMState newState) => stateMachine.ChangeState(newState);
}
