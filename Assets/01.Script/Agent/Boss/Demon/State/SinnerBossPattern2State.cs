using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBossPattern2State : AgentState
{
    private SinnerBoss _sinnerBoss;
    public SinnerBossPattern2State(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
    }

    public override void Enter()
    {
        base.Enter();   
        _sinnerBoss.StartCoroutine(Pattern2());
    }

    public override void Update()
    {
        base.Update();
        if(_isTriggerCall)
        {
            _sinnerBoss.StateMachine.ChangeState(FSMState.Idle);
        }
    }

    private IEnumerator Pattern2()
    {
        float one = -6.75f;
        for (int i =0;i<7;++i)
        {
            float spawnPos = one + 2.25f * i;
            GameObject obj =_sinnerBoss.PatternObjSpawn(_sinnerBoss.pattern2Obj,
                _sinnerBoss.transform, Quaternion.identity);
            
            obj.transform.localPosition = new Vector2(spawnPos, 15);

        }
        yield return new WaitForSeconds(1f);
        float two = -7.875f;
        for (int i = 0; i < 8; ++i)
        {
            float spawnPos = two + 2.25f * i;
            GameObject obj = _sinnerBoss.PatternObjSpawn(_sinnerBoss.pattern2Obj,
                _sinnerBoss.transform, Quaternion.identity);
            obj.transform.localPosition = new Vector2(spawnPos, 15);
        }
    }

}
