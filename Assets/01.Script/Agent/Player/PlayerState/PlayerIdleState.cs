using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    // Start is called before the first frame update
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //_player.MovementCompo.StopImmediately();

    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(Mathf.Abs(_player._inputReader.Movement.x) > 0.1f)
            _player.StateMachine.ChangeState(PlayerStateEnum.Run);
        _player.MovementCompo.SetMovement(0);
    }
}
