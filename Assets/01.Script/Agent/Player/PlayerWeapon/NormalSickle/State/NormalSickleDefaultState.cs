using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleDefaultState  : WeaponState<NormalSickleEnum>
{
    public NormalSickleDefaultState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.inputReader.MouseSpecialEvent += HandleSpecialEvent;
    }

    public override void Exit()
    {
        _owner.inputReader.MouseSpecialEvent -= HandleSpecialEvent;
        base.Exit();
    }

    private void HandleSpecialEvent()
    {
        _stateMachine.ChangeState(NormalSickleEnum.Special);
    }

    public override void StateUpdate()
    {

        base.StateUpdate();
    }
}
