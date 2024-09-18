using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected Enemy _enemy;
    protected EnemyStateMachine _machine;
    protected int _animaHash;
    protected bool _isEndTrigger;

    public EnemyState(Enemy enemy, EnemyStateMachine machine, string stateName)
    {
        _enemy = enemy;
        _machine = machine;
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

    public virtual void AnimationFinishTrigger()
    {
        _isEndTrigger = true;
    }

}
