using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleAttackState : WeaponState<NormalSickleEnum>
{

    public NormalSickleAttackState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if(_isEndTrigger)
        {
            _stateMachine.ChangeState(NormalSickleEnum.Idle);
        }
    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
    }

    public override void AnimationAttack()
    {
        base.AnimationAttack();
        _owner.Attack();

    }


}
