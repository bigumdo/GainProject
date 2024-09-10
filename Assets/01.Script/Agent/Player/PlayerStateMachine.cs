using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    
    private Dictionary<PlayerStateEnum,PlayerState> stateDictionary;
    public PlayerState CurrentState{ get; private set; }
    private Player _player;

    public PlayerStateMachine()
    {
        stateDictionary = new Dictionary<PlayerStateEnum,PlayerState>();
    }

    public void Initialize(PlayerStateEnum startState,Player player )
    {
        _player = player;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(PlayerStateEnum state)
    {
        CurrentState.Exit();
        CurrentState = stateDictionary[state];
        CurrentState.Enter();
    }
    
    public void AddState(PlayerStateEnum stateEnum,PlayerState state)
    {
        stateDictionary.Add(stateEnum,state);
    }

}
