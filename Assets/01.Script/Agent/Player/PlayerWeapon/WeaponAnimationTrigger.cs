using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationTrigger : MonoBehaviour
{
    private Weapon _weapon;

    private void Awake()
    {
        _weapon = GetComponentInParent<Weapon>();
    }

    public void AnimationEnd()
    {
        _weapon.AnimationEnd();
    }

    public void AnimationAttack()
    {
        _weapon.AnimationAttack();
    }
}
