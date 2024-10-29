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
        base.UpdateState();
        if(_player.MovementCompo.IsGorund)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * _player.moveSpeed);
    }
}
