using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleAttackState : WeaponState<NormalSickleEnum>
{
    public NormalSickleAttackState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        if (_isAttack)
            _stateMachine.ChangeState(NormalSickleEnum.Idle);
    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
        _owner.Attack();
        _isAttack = true;
    }
}
