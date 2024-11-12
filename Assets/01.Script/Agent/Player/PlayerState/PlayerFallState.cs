using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    // Start is called before the first frame update
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately();
        _player.MovementCompo.Rigid.AddForce(new Vector2(0,-_player.gravity), ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_player.MovementCompo.IsGorund)
        {
            _player.ResetJumpCnt();
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
