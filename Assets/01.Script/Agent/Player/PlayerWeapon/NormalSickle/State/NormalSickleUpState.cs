using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleUpState : NormalSickleDefaultState
{
    private float startTime;
    public NormalSickleUpState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }

    public override void Enter()
    {
        startTime = Time.time;
        base.Enter();
        _owner.inputReader.MouseAttackEvent += HandleAttack;
        _owner.inputReader.MouseSpecialEvent += HandleSpecialEvent;

    }

    public override void Exit()
    {
        _owner.inputReader.MouseAttackEvent -= HandleAttack;
        _owner.inputReader.MouseSpecialEvent -= HandleSpecialEvent;

        base.Exit();
    }

    private void HandleSpecialEvent()
    {

        _stateMachine.ChangeState(NormalSickleEnum.Special);
    }

    private void HandleAttack()
    {
        _stateMachine.ChangeState(NormalSickleEnum.Attack);
    }

    public override void StateUpdate()
    {
        if(Time.time - startTime > 3)
            _stateMachine.ChangeState(NormalSickleEnum.Idle);

    }

    public override void AnimationEndTrigger()
    {
        base.AnimationEndTrigger();
    }
}
