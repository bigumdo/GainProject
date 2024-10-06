using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSickleUpState : WeaponState<NormalSickleEnum>
{
    public NormalSickleUpState(Player owner, WeaponStateMachine<NormalSickleEnum> stateMachine, string animaHash) : base(owner, stateMachine, animaHash)
    {
    }

}
