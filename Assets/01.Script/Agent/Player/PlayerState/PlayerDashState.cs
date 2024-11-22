using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : AgentState
{
    private float currentDashTime;
    private Player _player;

    public PlayerDashState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _player = agent as Player;
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo.IsOnDash = true;
        currentDashTime = _player.dashTime;
        _player.PlayerMovementCompo.Dash(_player.dashPower);
        _player.IsWeaponFlip = false;
    }

    public override void Exit()
    {
        _player.MovementCompo.Rigid.gravityScale = 1;
        _player.PlayerMovementCompo.IsOnDash = false;
        _player.IsWeaponFlip = true;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(currentDashTime <= 0)
        {
            _player.stateMachine.ChangeState(FSMState.Idle);
            currentDashTime = _player.dashTime;

        }
        else
        {
            //_player.PlayerMovementCompo.Dash(_player.dashPower);
            currentDashTime -= Time.deltaTime;
        }

    }
}
