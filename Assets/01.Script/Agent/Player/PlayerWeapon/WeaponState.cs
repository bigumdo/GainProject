using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState<T> where T : Enum
{
    protected Player _owner;
    protected WeaponStateMachine<T> _stateMachine;
    protected int _animaHash;

    protected bool _isEndTrigger;

    public WeaponState(Player owner, WeaponStateMachine<T> stateMachine, string animaHash)
    {
        _owner = owner;
        _stateMachine = stateMachine;
        _animaHash = Animator.StringToHash( animaHash);
    }

    public virtual void Enter()
    {
        _owner.AnimatorCompo.SetBool(_animaHash, true);
    }

    public virtual void StateUpdate()
    {

    }

    public virtual void Exit()
    {
        _owner.AnimatorCompo.SetBool(_animaHash, false);
    }

    public virtual void AnimationEndTrigger()
    {
        _isEndTrigger = true;
    }
}
