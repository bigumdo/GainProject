using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState<T> where T : Enum
{
    protected Player _owner;
    protected Weapon _weapon;
    protected WeaponStateMachine<T> _stateMachine;
    protected int _animaHash;
    protected bool _isAttack = true;

    protected bool _isEndTrigger;
    protected bool _isAttackTrigger;

    public WeaponState(Player owner,Weapon weapon, WeaponStateMachine<T> stateMachine, string animaHash)
    {
        _owner = owner;
        _weapon = weapon;
        _stateMachine = stateMachine;

        _animaHash = Animator.StringToHash( animaHash);
    }

    public virtual void Enter()
    {
        _isEndTrigger = false;
        _isAttackTrigger = false;
        _weapon.AnimatorCompo.SetBool(_animaHash, true);
    }

    public virtual void StateUpdate()
    {

    }

    public virtual void Exit()
    {
        _weapon.AnimatorCompo.SetBool(_animaHash, false);
    }

    public virtual void AnimationEndTrigger()
    {
        _isEndTrigger = true;
    }

    public virtual void AnimationAttack()
    {
        _isAttackTrigger = true;
    }
}
