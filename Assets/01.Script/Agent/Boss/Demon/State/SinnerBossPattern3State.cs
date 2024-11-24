using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBossPattern3State : AgentState
{
    private SinnerBoss _sinnerBoss;
    public SinnerBossPattern3State(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
    }




}
