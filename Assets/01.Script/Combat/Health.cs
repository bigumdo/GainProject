using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamage
{
    public UnityEvent OnHitEvent;
    public UnityEvent OnDeadEvent;

    private Agent _owner;
    private int _currentHealth;
    private bool _isCritical;

    public void Initialize(Agent agent)
    {
        _owner = agent;
        _currentHealth = _owner.Stat.maxHealth.GetValue();
    }

    public void ApplyDamage(int damage)
    {
        if (_owner.isDead) return;

        _isCritical = _owner.Stat.IsCritical(ref damage);

        if (_isCritical)
        {

        }

        damage = _owner.Stat.ArmorDamage(damage);

        Mathf.Clamp(_currentHealth - damage, 0, _owner.Stat.maxHealth.GetValue());

    }
    public float GetNormalizeHealth()
    {
        return (float)_currentHealth / _owner.Stat.maxHealth.GetValue();
    }
}
