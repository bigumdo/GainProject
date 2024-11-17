using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : AgentMovement
{

    public void Attack(Vector3 dir)
    {
        StartCoroutine(AnimationDelay(dir));
        //Rigid.velocity = dir;
    }

    private IEnumerator AnimationDelay(Vector3 dir)
    {
        yield return new WaitForSeconds(0.2f);
        StopImmediately();
        Rigid.AddForce(dir * 3,ForceMode2D.Impulse);

    }



    protected override void FixedUpdate()
    {
        
    }
}
