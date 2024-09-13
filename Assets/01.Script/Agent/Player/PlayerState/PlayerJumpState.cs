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
        if (_isEndTrigger)
        {
            _isEndTrigger = false;
            _player.StateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}
