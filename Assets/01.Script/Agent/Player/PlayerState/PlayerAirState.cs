using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.inputReader.DashEvent += HandleDashEvent;
        _player.inputReader.JumpEvent += HandleJumpEvent;
    }

    public override void Exit()
    {
        _player.inputReader.DashEvent -= HandleDashEvent;
        _player.inputReader.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    private void HandleJumpEvent()
    {
        if(_player.CanJump)
            _player.StateMachine.ChangeState(PlayerStateEnum.Jump);
    }

    private void HandleDashEvent()
    {
        if (_player.PlayerMovementCompo.IsDash)
            _player.StateMachine.ChangeState(PlayerStateEnum.Dash);
    }

    public override void UpdateState()
    {
        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * 0.7f * _player.moveSpeed);
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    _player.StateMachine.ChangeState(PlayerStateEnum.Attack);
        //}
    }
}
