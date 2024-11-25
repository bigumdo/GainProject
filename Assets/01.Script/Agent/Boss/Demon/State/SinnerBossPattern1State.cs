using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SinnerBossPattern1State : AgentState
{
    private SinnerBoss _sinnerBoss;
    private int _cnt;
    private int _spawnCnt = 10;
    private bool _patternEnd;
    public SinnerBossPattern1State(Agent agent, AnimParamSO animParam) : base(agent, animParam)
    {
        _sinnerBoss = agent as SinnerBoss;
    }

    public override void Enter()
    {
        base.Enter();
        _cnt = 0;
        if (!_patternEnd)
            _sinnerBoss.StartCoroutine(Pattern1());
    }

    public override void Update()
    {
        base.Update();
        if(_patternEnd)
        {
            _cnt = 0;
            _patternEnd = false;
            _sinnerBoss.StateMachine.ChangeState(FSMState.Idle);
        }
    }

    private IEnumerator Pattern1()
    {
        for (int i = 0; i < _spawnCnt; ++i)
        {
            GameObject obj = _sinnerBoss.PatternObjSpawn(_sinnerBoss.pattern1Obj, _sinnerBoss.transform, Quaternion.identity);
            obj.transform.position = GameManager.Instance.Player.transform.position;
            _cnt++;
            yield return new WaitForSeconds(0.5f);
        }
            yield return new WaitForSeconds(1f);
        _patternEnd = true;
    }


}
