using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    private bool _attackCheck;
    private bool _animationEnd;
    private bool _attack = false;
    [SerializeField]private int _damage;

    private void OnEnable()
    {
        int dir = Random.Range(0, 2);
        int angle = Random.Range(30, 65);
        angle = dir > 0 ? angle : -angle;
        transform.rotation = Quaternion.Euler(0,0, angle);
    }

    public void Attack()
    {
        _attackCheck = true;
    }

    public void AnimationEnd()
    {
        _animationEnd = true;
    }

    private void Update()
    {
        if(_animationEnd)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_attackCheck && !_attack)
        {
            if(collision.TryGetComponent(out Player player))
            {
                player.HealthCompo.ApplyDamage(_damage);
                _attack = true;
            }
        }
    }
}
