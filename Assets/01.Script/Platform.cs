using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Player _player;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Player>(out Player p))
        {
            p.Platfrom = this;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player p))
        {
            p.Platfrom = null;

        }
    }

    public void SetIgnore(Collider2D target, float time)
    {
        StartCoroutine(IgnoreCollision(target, time));
    }

    private IEnumerator IgnoreCollision(Collider2D target, float time)
    {

        Physics2D.IgnoreCollision(target, _collider, true);//서로를 무시한다.
        yield return new WaitForSeconds(time);
        Physics2D.IgnoreCollision(target, _collider, false);//서로를 무시하지 않는다.
    }
}
