using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBossHitState : AgentState
{
    private SinnerBoss _sinnerBoss;
    public SinnerBossHitState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
    }

    public override void Enter()
    {
        base.Enter();
        _sinnerBoss.StateMachine.ChangeState(FSMState.Idle);
    }
}
