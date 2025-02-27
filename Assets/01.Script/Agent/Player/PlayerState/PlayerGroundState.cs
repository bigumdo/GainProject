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
            _player.StateMachine.ChangeState(FSMState.Dash);
    }

    private void HandleJumpEvent()
    {
        if (_player.inputReader.Movement.y < 0 && _player.Platfrom != null)
            _player.Platfrom.SetIgnore(_player.Collider,1f);
        else
            _player.StateMachine.ChangeState(FSMState.Jump);

    }

    public override void Update()
    {
        base.Update();
        if (!_player.MovementCompo.IsGorund)
            _player.StateMachine.ChangeState(FSMState.Fall);
    }
}
