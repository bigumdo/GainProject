using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : AgentMovement
{
    private Vector3 _dir;
    private Wolf _wolf;

    public override void Initialize(Agent agent)
    {
        base.Initialize(agent);
        _wolf = agent as Wolf;
    }
    public void Attack(Vector3 dir)
    {
        StartCoroutine(AnimationDelay(dir));
        //Rigid.velocity = dir;
    }

    private IEnumerator AnimationDelay(Vector3 dir)
    {
        yield return new WaitForSeconds(0.2f);
        StopImmediately();
        _dir = dir;
        //Rigid.gravityScale = 0;
        //Rigid.AddForce(new Vector2(dir.x,3),ForceMode2D.Impulse);
        AddForce(new Vector2(dir.x, 3));
    }



    protected override void FixedUpdate()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, _dir);
    }
}
