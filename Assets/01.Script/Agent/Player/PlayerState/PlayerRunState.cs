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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_player.inputReader.Movement.x == 0)
        {
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * _player.moveSpeed);
    }
}
