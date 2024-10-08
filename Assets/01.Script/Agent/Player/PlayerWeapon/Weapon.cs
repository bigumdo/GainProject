using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour

{
    public Player Owner { get; private set; }
    public Animator AnimatorCompo { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }

    public void StateMachine<T>(T e)
    {

    }

    protected virtual void Awake()
    {
        Owner = transform.root.GetComponent<Player>();
        AnimatorCompo = GetComponent<Animator>();
    }

    //public void SetWeapon()
    //{
    //    currentWeaon = GetComponentInChildren<IWeapon>();
    //}

}
