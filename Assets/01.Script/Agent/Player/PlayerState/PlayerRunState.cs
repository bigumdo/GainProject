using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundState
{
    private float _movement;

    public PlayerRunState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
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

    public override void Update()
    {
        base.Update();
        if (_player.inputReader.Movement.x == 0)
        {
            _player.stateMachine.ChangeState(FSMState.Idle);
        }
        

        _player.MovementCompo.SetMovement(_player.inputReader.Movement.x * _player.moveSpeed);
    }
}
