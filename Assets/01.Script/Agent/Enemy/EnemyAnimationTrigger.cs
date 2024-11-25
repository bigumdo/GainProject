using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    public Enemy enemy;
    public void AnimationEnd()
    {
        enemy.StateMachine.currentState.AnimationEndTrigger();
    }

    public void AnimationStart()
    {

    }

    public void DamageCaster()
    {
        enemy.Attack();
    }
}
