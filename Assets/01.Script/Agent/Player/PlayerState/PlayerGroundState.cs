using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : AgentState
{
    protected Player _player;
    public PlayerGroundState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _player = agent as Player;
    }

    // Start is called before the first frame update


    public override void Enter()
    {
        base.Enter();
        _player.inputReader.JumpEvent += HandleJumpEvent;
        _player.inputReader.DashEvent += HandleDashEvent;
    }

    public override void Exit()
    {
        _player.inputReader.JumpEvent -= HandleJumpEvent;
        _player.inputReader.DashEvent -= HandleDashEvent;
        base.Exit();
    }

    private void HandleDashEvent()
    {
        if(_player.PlayerMovementCompo.IsDash)
            _player.stateMachine.ChangeState(FSMState.Dash);
    }

    private void HandleJumpEvent()
    {
        _player.stateMachine.ChangeState(FSMState.Jump);

    }

    public override void Update()
    {
        if (!_player.MovementCompo.IsGorund)
            _player.stateMachine.ChangeState(FSMState.Fall);
    }
}
