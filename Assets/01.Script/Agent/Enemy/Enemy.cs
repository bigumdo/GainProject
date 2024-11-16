using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    [SerializeField] private StateListSO states;


    private StateMachine _stateMachine;

    protected override void Awake()
    {
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();
        SpriteRendererCompo = visual.GetComponent<SpriteRenderer>();
        MovementCompo = GetComponent<IMovement>();
        MovementCompo.Initialize(this);
        _stateMachine = new StateMachine(states, this);
    }

    private void Start()
    {
        _stateMachine.Initialize(FSMState.Idle);
    }

    public void ChangeState(FSMState newState) => _stateMachine.ChangeState(newState);
}
