using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SphereDamageCaster : DamageCaster
{
    [SerializeField,Range(0,2)] private float _castradius;
    [SerializeField,Range(0,2)] private float _castingRange;


    public override bool DamageCast()
    {

        Vector2 startPos = StartPos();
        RaycastHit2D hit = Physics2D.CircleCast(startPos, _castradius, startPos, _castingRange, targetLayer);
        bool isHit = hit.collider != null;
        if (isHit)
        {
            if(hit.collider.TryGetComponent<IDamage>(out IDamage health))
            {
                int damage = _owner.Stat.GetDamage();

                health.ApplyDamage(damage);
            }
        }
        return isHit;
    }

    public Vector2 StartPos()
    {
        return _owner.SpriteRendererCompo.flipX ? transform.position + Vector3.left : transform.position + Vector3.right;
    }

    private void OnDrawGizmosSelected()
    {
        if(_owner == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(StartPos(), _castingRange);
    }

}
