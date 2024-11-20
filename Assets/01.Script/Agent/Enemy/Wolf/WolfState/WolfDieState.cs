using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfDieState : AgentState
{
    private Wolf _wolf;
    public WolfDieState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _wolf = agent as Wolf;
    }

    public override void Enter()
    {
        base.Enter();
        _wolf.WolfMoveCompo.StopImmediately();
        //_wolf.isDead = true;
        _wolf.powerChargeBar.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(_isTriggerCall)
            GameObject.Destroy(_wolf.gameObject);
    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
    }
}
