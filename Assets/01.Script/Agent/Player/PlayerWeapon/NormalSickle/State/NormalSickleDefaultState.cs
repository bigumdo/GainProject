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
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void StateUpdate()
    {

        base.StateUpdate();
    }
}
