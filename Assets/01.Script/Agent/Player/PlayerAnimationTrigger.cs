using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    public Player player;
    public void AnimationEnd()
    {
        player.StateMachine.CurrentState.AnimationFinishTrigger();
    }

    public void DamageCaster()
    {
        player.Attack();
    }
}
