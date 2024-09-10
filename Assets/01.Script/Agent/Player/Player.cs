using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Agent
{
    public InputReader _inputReader;

    [Header("Setting")]
    private float _moveSpeed;
    
    public PlayerStateMachine StateMachine { get; protected set; }

    protected void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();
        
        foreach(PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();

            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                PlayerState state = Activator.CreateInstance(
                    t, this, StateMachine, typeName) as PlayerState;
                StateMachine.AddState(stateEnum, state);
            }catch(Exception ex)
            {
                Debug.LogError($"{typeName} is loading error! check Message");
                Debug.LogError(ex.Message);
            }
        }

    }

    public void Update()
    {
        
    }
}
