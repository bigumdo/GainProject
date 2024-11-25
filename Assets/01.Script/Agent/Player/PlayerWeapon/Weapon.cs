using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour, IWeapon
{
    public Player Owner { get; private set; }
    public Animator AnimatorCompo { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    [Header("Setting")]
    public float attackDelay;

    private ParticleSystem effectObj;
    public bool isAttack;



    protected virtual void Awake()
    {
        Owner = transform.root.GetComponent<Player>();
        AnimatorCompo = GetComponentInChildren<Animator>();
    }

    public virtual void Attack()
    {

    }

    public void SetDamage()
    {
        
    }

    public virtual void AnimationEnd()
    {

    }

    public virtual void AnimationAttack()
    {

    }



}
