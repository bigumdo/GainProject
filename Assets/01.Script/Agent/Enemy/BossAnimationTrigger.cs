using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationTrigger : MonoBehaviour
{
    private SinnerBoss _sinner;

    private void Awake()
    {
        _sinner = transform.root.GetComponent<SinnerBoss>();
    }

    public void AnimationTrigger()
    {
        _sinner.StateMachine.currentState.AnimationEndTrigger();
    }

}
