using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleIdleState : NormalSickleDefaultState
{
    public NormalSickleIdleState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }
    public override void Enter()
    {

        base.Enter();
        _owner.inputReader.MouseAttackEvent += HandleAttackEvent;
        _isAttack = false;

    }

    public override void Exit()
    {
        _owner.inputReader.MouseAttackEvent -= HandleAttackEvent;
        base.Exit();
    }

    private void HandleAttackEvent()
    {
        _stateMachine.ChangeState(NormalSickleEnum.Attack);
    }
}

