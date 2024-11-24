using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBossIdleState : AgentState
{
    private SinnerBoss _sinnerBoss;
    private float time;
    private float patternTime;
    public SinnerBossIdleState(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
        patternTime = _sinnerBoss.patternTime;
    }

    public override void Update()
    {
        base.Update();
        if (patternTime > time)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            int Number = Random.Range(0, 3);

            switch (Number)
            {
                case 0:
                    _sinnerBoss.stateMachine.ChangeState(FSMState.Pattern1);

                    break;
                case 1:
                    _sinnerBoss.stateMachine.ChangeState(FSMState.Pattern2);

                    break;
                case 2:
                    _sinnerBoss.stateMachine.ChangeState(FSMState.Pattern3);

                    break;
            }

            //_sinnerBoss.AgentRenderer.SetParam(_animParam,Number);
        }
    }


}
