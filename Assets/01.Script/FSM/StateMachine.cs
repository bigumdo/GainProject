using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class StateMachine 
{
    public AgentState currentState { get; private set; }
    private Dictionary<FSMState, AgentState> _states;
    private Agent _agent;

    public StateMachine(StateListSO fsmStates, Agent agent)
    {
        _states = new Dictionary<FSMState, AgentState>();
        _agent = agent;
        foreach (StateSO state in fsmStates.stateList)
        {
            try
            {
                Type t = Type.GetType(state.className);
                var entityState = Activator.CreateInstance(t, agent, state.animParam) as AgentState;
                _states.Add(state.StateEnum, entityState);
            }
            catch (Exception ex)
            {
                Debug.Log(Type.GetType(state.className));
                Debug.Log(state.animParam);
                Debug.LogError($"{state.className} loading Error, Message : {ex.Message}");
            }
        }

    }

    public void Initialize(FSMState startState)
    {
        currentState = GetState(startState);
        Debug.Assert(currentState != null, $"{startState} state not found");
        currentState.Enter();
    }

    public void ChangeState(FSMState newState)
    {
        
        
        currentState.Exit();
        currentState = GetState(newState);
        Debug.Assert(currentState != null, $"{newState} state not found");
        currentState.Enter();
    }

    public AgentState GetState(FSMState state) => _states.GetValueOrDefault(state);

    public void UpdateStateMachine()
    {
        currentState.Update();
    }

}
