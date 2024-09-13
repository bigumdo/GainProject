using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState 
{

    protected Player _player;
    protected PlayerStateMachine _machine;
    protected int _animaHash;

    protected bool _isEndTrigger;

    public PlayerState(Player player,PlayerStateMachine stateMachine,string stateName)
    {
        _player = player;
        _machine = stateMachine;
        _animaHash = Animator.StringToHash(stateName);
    }
    public virtual void Enter()
    {
        _player.AnimatorCompo.SetBool(_animaHash,true);
        _isEndTrigger = false;
    }

    public virtual void Exit()
    {
        _player.AnimatorCompo.SetBool(_animaHash,false);
    }

    public virtual void UpdateState()
    {


    }
    
    public virtual void AnimationFinishTrigger()
    {
        _isEndTrigger = true;
    }
}
