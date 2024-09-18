using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Dictionary<EnemyStateEnum, EnemyState> stateDictionary;
    public EnemyState CurrentState { get; private set; }
    private Enemy _enemy;

    public EnemyStateMachine()
    {
        stateDictionary = new Dictionary<EnemyStateEnum, EnemyState>();
    }

    public void Initialize(EnemyStateEnum enemyState, Enemy enemy)
    {
        _enemy = enemy;
        CurrentState = stateDictionary[enemyState];
        CurrentState.Enter();
    }

    public void ChangeState(EnemyStateEnum state)
    {
        CurrentState.Exit();
        CurrentState = stateDictionary[state];
        CurrentState.Enter();
    }

    public void AddState(EnemyStateEnum stateEnum, EnemyState state)
    {
        stateDictionary.Add(stateEnum, state);
    }
}
