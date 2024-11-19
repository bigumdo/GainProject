using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
    }



    public override void Enter()
    {
        base.Enter();


        _player.MovementCompo.StopImmediately();
        _player.DecreaseJumpCount();
        _player.PlayerMovementCompo.Jump(_player.jumpPower);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (_player.MovementCompo.Rigid.velocity.y < -0.5f)
            _player.stateMachine.ChangeState(FSMState.Fall);
    }
}
