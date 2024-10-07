using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine<T> where T : Enum
{
    public Dictionary<T, WeaponState<T>> StateDictionary = 
        new Dictionary<T, WeaponState<T>>();
    public WeaponState<T> CurrentState { get; private set; }
    public Player _owner;

    

    public void Initialize(T startState, Player owner)
    {
        _owner = owner;
        CurrentState = StateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(T stateEnum)
    {
        Debug.Log(1);

        CurrentState.Enter();
        CurrentState = StateDictionary[stateEnum];
        CurrentState.Exit();
    }

    public void AddState(T stateEnum, WeaponState<T> weaponState)
    {
        StateDictionary.Add(stateEnum,weaponState);
    }

}
