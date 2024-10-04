using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    // Start is called before the first frame update
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
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
        if (_player.MovementCompo.Rigid.velocity.y < -0.5f)
            _player.StateMachine.ChangeState(PlayerStateEnum.Fall);
        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * _player.moveSpeed);
    }
}
