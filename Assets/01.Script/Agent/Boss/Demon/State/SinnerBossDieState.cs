using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBossDieState : AgentState
{
    private SinnerBoss _sinnerBoss;
    public SinnerBossDieState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
        _sinnerBoss.gameObject.SetActive(false);
    }


}
