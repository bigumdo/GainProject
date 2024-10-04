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
    }

    public override void Exit()
    {
        _player.inputReader.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    private void HandleJumpEvent()
    {
        _player.StateMachine.ChangeState(PlayerStateEnum.Jump);
        _player.MovementCompo.Jump(_player.jumpPower);
    }

    public override void UpdateState()
    {
        if(!_player.MovementCompo.IsGorund)
            _player.StateMachine.ChangeState(PlayerStateEnum.Fall);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _player.StateMachine.ChangeState(PlayerStateEnum.Attack);
        }
    }
}
