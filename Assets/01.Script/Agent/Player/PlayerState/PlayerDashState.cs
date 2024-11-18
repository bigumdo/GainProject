using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private float currentDashTime;
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo.IsOnDash = true;
        currentDashTime = _player.dashTime;
        _player.PlayerMovementCompo.Dash(_player.dashPower);

    }

    public override void Exit()
    {
        _player.MovementCompo.Rigid.gravityScale = 1;
        _player.PlayerMovementCompo.IsOnDash = false;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(currentDashTime <= 0)
        {
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
            currentDashTime = _player.dashTime;

        }
        else
        {
            //_player.PlayerMovementCompo.Dash(_player.dashPower);
            currentDashTime -= Time.deltaTime;
        }

    }
}
