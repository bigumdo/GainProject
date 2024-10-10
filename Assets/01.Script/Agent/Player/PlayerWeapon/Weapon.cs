using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon: MonoBehaviour 
{
    public Player Owner { get; private set; }
    public Animator AnimatorCompo { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    [Header("Setting")]
    public float attackDelay;


    protected virtual void Awake()
    {
        Owner = transform.root.GetComponent<Player>();
        AnimatorCompo = GetComponentInChildren<Animator>();
    }

    public virtual void AnimationEnd()
    {

    }

    public void Delay(Action action, float delay)
    {
        StartCoroutine( DelayCoroutine(action, delay));
    }

    private IEnumerator DelayCoroutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    //public void SetWeapon()
    //{
    //    currentWeaon = GetComponentInChildren<IWeapon>();
    //}

}
