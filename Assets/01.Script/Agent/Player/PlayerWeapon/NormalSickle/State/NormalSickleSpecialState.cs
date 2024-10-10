using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalSickleSpecialState : WeaponState<NormalSickleEnum>
{
    public NormalSickleSpecialState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
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
        if (_isEndTrigger)
        {
            _weapon.Delay(()=>_stateMachine.ChangeState(NormalSickleEnum.Idle), _weapon.attackDelay);
            _isEndTrigger = false;
        }
    }



}
