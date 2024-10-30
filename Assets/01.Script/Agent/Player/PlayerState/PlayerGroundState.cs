using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    // Start is called before the first frame update
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _player.inputReader.JumpEvent += HandleJumpEvent;
        _player.inputReader.PlayerDashEvent += HandleDashEvent;
    }

    public override void Exit()
    {
        _player.inputReader.JumpEvent -= HandleJumpEvent;
        _player.inputReader.PlayerDashEvent -= HandleDashEvent;
        base.Exit();
    }

    private void HandleDashEvent()
    {
        if(_player.PlayerMovementCompo.IsDash)
            _player.StateMachine.ChangeState(PlayerStateEnum.Dash);
    }

    private void HandleJumpEvent()
    {
        _player.StateMachine.ChangeState(PlayerStateEnum.Jump);

    }

    public override void UpdateState()
    {
        if(!_player.MovementCompo.IsGorund)
            _player.StateMachine.ChangeState(PlayerStateEnum.Fall);
        
            
    }
}
