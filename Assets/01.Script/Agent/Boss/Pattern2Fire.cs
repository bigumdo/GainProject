using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2Fire : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.localPosition += Vector3.down * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.HealthCompo.ApplyDamage(_damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
