using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    // Start is called before the first frame update
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_isEndTrigger)
            _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
        _player.MovementCompo.SetMovement(0);
    }

    
}
