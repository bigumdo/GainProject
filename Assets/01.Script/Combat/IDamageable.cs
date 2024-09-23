using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Str,
    Luc
}


public interface IDamageable
{
    public void ApplyDamage(int damage, Vector3 hitPoint, Vector3 normal, 
        float knockbackPower, Agent dealer, DamageType damageType);
}
