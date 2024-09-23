using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverapDamageCaster : DamageCaster
{
    [SerializeField] private float _castRadius;
    [SerializeField] private int _maxColliderCount = 1;

    private Collider[] _colliders;

    public override void InitCaster(Agent agent)
    {
        base.InitCaster(agent);
        _colliders = new Collider[_maxColliderCount];
    }

    public override bool DamageCast()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, _castRadius, _colliders, targetLayer);

        for (int i = 0; i < count; ++i)
        {
            Transform target = _colliders[i].transform;
            if (target.TryGetComponent(out IDamageable health))
            {
                //int damage = _owner.Stat.GetDamage();
                //float knockBackPower = 7f;

                Vector3 direction = (target.position + Vector3.up) - transform.position;
                //if (Physics.Raycast(transform.position, target.position, out RaycastHit hit, direction.magnitude, targetLayer))
                //{
                //    health.ApplyDamage(damage, target.position, -direction.normalized, knockBackPower, _owner,
                //        DamageType.Melee);
                //}
                //else
                //{
                //    health.ApplyDamage(damage, target.position, -direction.normalized, knockBackPower,
                //        _owner, DamageType.Melee);
                //}
            }
        }
        OnDamageCastEvent?.Invoke();

        return count >= 1;
    }


}
