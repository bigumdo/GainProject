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
        _player._inputReader.MovementEvent += HandlMovementEvent;
        _player.MovementCompo.StopImmediately();

    }


    public override void Exit()
    {
        _player._inputReader.MovementEvent -= HandlMovementEvent;
        base.Exit();
    }
    private void HandlMovementEvent(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0.1f)
            _player.StateMachine.ChangeState(PlayerStateEnum.Run);
    }
}
