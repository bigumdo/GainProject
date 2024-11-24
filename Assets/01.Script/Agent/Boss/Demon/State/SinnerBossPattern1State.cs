using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBossPattern1State : AgentState
{
    private SinnerBoss _sinnerBoss;
    public SinnerBossPattern1State(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
    }


}
