using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : AgentState
{
    private Player _player;

    public PlayerFallState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _player = agent as Player;
    }

    // Start is called before the first frame update

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately();
        _player.MovementCompo.Rigid.AddForce(new Vector2(0,-_player.gravity), ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(_player.MovementCompo.IsGorund)
        {
            _player.ResetJumpCnt();
            _player.stateMachine.ChangeState(FSMState.Idle);
        }
    }
}
