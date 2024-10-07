using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleSpecialState : WeaponState<NormalSickleEnum>
{
    public NormalSickleSpecialState(Player owner, Weapon weapon, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, weapon, stateMachine, animaHash)
    {
    }
}
