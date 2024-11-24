using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : AgentState
{
    private Player _player;
    public PlayerHitState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _player = agent as Player;
    }

    public override void Enter()
    {
        
        base.Enter();
        
    }

    public override void Update()
    {
        base.Update();
            if (_isTriggerCall)
                _player.stateMachine.ChangeState(FSMState.Idle);
    }
}
