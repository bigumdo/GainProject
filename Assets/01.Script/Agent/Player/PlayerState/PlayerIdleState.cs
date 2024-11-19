using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
    }

    // Start is called before the first frame update

    public override void Enter()
    {
        base.Enter();
        //_player.MovementCompo.StopImmediately();

    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(Mathf.Abs(_player.inputReader.Movement.x) > 0.1f)
            _player.stateMachine.ChangeState(FSMState.Run);
        _player.MovementCompo.SetMovement(0);
    }
}
