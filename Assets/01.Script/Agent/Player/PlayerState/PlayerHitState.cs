using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
    public PlayerHitState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void UpdateState()
    {
        
            if (_isEndTrigger)
                _player.StateMachine.ChangeState(PlayerStateEnum.Idle);
    }
}
