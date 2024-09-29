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


    }
    public float GetNormalizeHealth()
    {
        return (float)_currentHealth / _owner.Stat.maxHealth.GetValue();
    }
}
