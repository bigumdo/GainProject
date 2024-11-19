using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : AgentState
{
    protected Player _player;
    public PlayerAirState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _player = agent as Player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.inputReader.DashEvent += HandleDashEvent;
        _player.inputReader.JumpEvent += HandleJumpEvent;
    }

    public override void Exit()
    {
        _player.inputReader.DashEvent -= HandleDashEvent;
        _player.inputReader.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    private void HandleJumpEvent()
    {
        if(_player.CanJump)
            _player.stateMachine.ChangeState(FSMState.Jump);
    }

    private void HandleDashEvent()
    {
        if (_player.PlayerMovementCompo.IsDash)
            _player.stateMachine.ChangeState(FSMState.Dash);
    }

    public override void Update()
    {
        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * 0.7f * _player.moveSpeed);
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    _player.StateMachine.ChangeState(PlayerStateEnum.Attack);
        //}
    }
}
