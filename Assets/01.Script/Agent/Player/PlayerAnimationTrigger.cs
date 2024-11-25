using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    public Player player;
    public void AnimationEnd()
    {
        player.StateMachine.currentState.AnimationEndTrigger();


    }

    public void DamageCaster()
    {
        player.Attack();
    }
}
