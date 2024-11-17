using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    public Enemy enemy;
    public void AnimationEnd()
    {
        enemy.stateMachine.currentState.AnimationEndTrigger();
    }

    public void AnimationStart()
    {

    }

    public void DamageCaster()
    {
        enemy.Attack();
    }
}
