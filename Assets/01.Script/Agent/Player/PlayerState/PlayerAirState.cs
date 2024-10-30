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
        _player.inputReader.PlayerDashEvent += HandleDashEvent;
    }

    public override void Exit()
    {
        _player.inputReader.PlayerDashEvent -= HandleDashEvent;
        base.Exit();
    }

    private void HandleDashEvent()
    {
        if (_player.PlayerMovementCompo.IsDash)
            _player.StateMachine.ChangeState(PlayerStateEnum.Dash);
    }

    public override void UpdateState()
    {
        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * _player.moveSpeed);
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    _player.StateMachine.ChangeState(PlayerStateEnum.Attack);
        //}
    }
}
