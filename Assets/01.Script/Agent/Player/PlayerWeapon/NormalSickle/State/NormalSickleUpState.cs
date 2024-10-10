using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleUpState : NormalSickleDefaultState
{
    public NormalSickleUpState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.inputReader.MouseAttackEvent += HandleAttack;
    }

    public override void Exit()
    {
        _owner.inputReader.MouseAttackEvent += HandleAttack;
        base.Exit();
    }

    private void HandleAttack()
    {
        _stateMachine.ChangeState(NormalSickleEnum.Attack);
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
    }
}
