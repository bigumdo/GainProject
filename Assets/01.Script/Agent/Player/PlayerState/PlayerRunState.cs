using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    private float _movement;
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player._inputReader.MovementEvent += HandleMovementEvent;
    }

    public override void Exit()
    {
        _player._inputReader.MovementEvent -= HandleMovementEvent;
        base.Exit();
    }

    private void HandleMovementEvent(Vector2 movement)
    {
        _movement = movement.x;
    }

    public override void UpdateState()
    {
        if(_movement == 0)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        _player.MovementCompo.SetMovement(_movement * _player.moveSpeed);
    }
}
