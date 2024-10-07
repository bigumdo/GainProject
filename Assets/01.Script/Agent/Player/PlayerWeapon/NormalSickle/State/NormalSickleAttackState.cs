using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleAttackState : WeaponState<NormalSickleEnum>
{
    public NormalSickleAttackState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }
}
