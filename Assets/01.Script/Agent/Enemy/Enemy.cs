using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    [SerializeField] private StateListSO states;


    protected override void Awake()
    {
        base.Awake();
        StateMachine = new StateMachine(states,this);

    }

    private void Start()
    {
        StateMachine.Initialize(FSMState.Idle);
    }

    private void Update()
    {
        if(isDead) return;
            StateMachine.UpdateStateMachine();
    }

    public override void Die()
    {
        StateMachine.ChangeState(FSMState.Die);
    }

    public override void Attack()
    {
        DamageCasterCompo.DamageCast();
    }

    public void ChangeState(FSMState newState) => StateMachine.ChangeState(newState);
}
