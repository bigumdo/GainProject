using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamage
{

    private Agent _owner;
    private int _currentHealth;

    public void Initialize(Agent agent)
    {
        _owner = agent;
        _currentHealth = _owner.Stat.maxHealth.GetValue();
    }

    public void ApplyDamage(int damage)
    {
        if (_owner.isDead) return;

        if (_owner.Stat.IsCritical(ref damage))
        {

        }

        damage = _owner.Stat.ArmorDamage(damage);

    }
    public float GetNormalizeHealth()
    {
        return (float)_currentHealth / _owner.Stat.maxHealth.GetValue();
    }
}
