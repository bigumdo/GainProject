using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    // Start is called before the first frame update
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }
    

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo.Jump(_player.jumpPower);



    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_player.MovementCompo.Rigid.velocity.y < -0.5f)
            _player.StateMachine.ChangeState(PlayerStateEnum.Fall);
    }
}
