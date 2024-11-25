using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinnerBoss : Agent
{
    [SerializeField] private StateListSO _states;
    [SerializeField] private AnimParamSO _patternNumber;
    public GameObject pattern1Obj;
    public GameObject pattern2Obj;
    public GameObject GameClearPanel;
    public float patternTime;
    public bool start = false;

    public AgentRenderer AgentRenderer { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        AgentRenderer = GetComponent<AgentRenderer>();
        StateMachine = new StateMachine(_states, this);
        StateMachine.Initialize(FSMState.Idle);
    }

    public void Update()
    {
        //StateMachine.CurrentState.UpdateState();
        StateMachine.UpdateStateMachine();

    }

    public GameObject PatternObjSpawn(GameObject prefab,Transform transform, Quaternion quaternion)
    {
        return Instantiate(prefab,transform);
    }

    public override void Die()
    {
        base.Die();
        GameClearPanel.SetActive(true);
        StateMachine.ChangeState(FSMState.Die);
    }
}
