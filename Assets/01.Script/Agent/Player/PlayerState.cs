using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState 
{

    protected Player _player;
    protected PlayerStateMachine _machine;
    protected int _animaHash;

    public PlayerState(Player player,PlayerStateMachine stateMachine,string stateName)
    {
        _player = player;
        _machine = stateMachine;
        _animaHash = Animator.StringToHash(stateName);
    }
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
         
    }

    public virtual void UpdateState()
    {


    }
}
