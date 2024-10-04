using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    // Start is called before the first frame update
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.Rigid.AddForce(new Vector2(0,-_player.gravity), ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        
        base.Exit();
    }

    private void HandleMovementEvent(Vector2 obj)
    {
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_player.MovementCompo.IsGorund)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * _player.moveSpeed);
    }
}
