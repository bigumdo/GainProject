using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackState : AgentState
{
    private Wolf _wolf;
    private WolfMovement _movement;
    public WolfAttackState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _wolf = agent as Wolf;
        _movement = _wolf.WolfMoveCompo;
    }

    public override void Enter()
    {
        base.Enter();
        _wolf.powerChargeBar.gameObject.SetActive(false);
        Vector3 vec = GameManager.Instance.Player.transform.position - _wolf.transform.position;
        _movement.Attack(vec.normalized * (vec.sqrMagnitude + 1));
    }

    public override void Exit()
    {
        _movement.StopImmediately();
        _movement.Rigid.gravityScale = 1;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(_isTriggerCall)
        {
            _movement.StopImmediately();
            _wolf.stateMachine.ChangeState(FSMState.Idle);
        }
    }
}
