using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHitState : AgentState
{
    private Wolf _wolf;
    public WolfHitState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _wolf = agent as Wolf;
    }

    public override void Enter()
    {
        _wolf.MovementCompo.StopImmediately();
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(_isTriggerCall)
            _wolf.StateMachine.ChangeState(FSMState.Idle);
    }
}
