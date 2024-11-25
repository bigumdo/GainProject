using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartArea : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private GameObject startPillar;
    [SerializeField] private SinnerBoss _boss;


    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {

            StartCoroutine(startA());
        }

    }

    private IEnumerator startA()
    {
        yield return new WaitForSeconds(0.2f);
        startPillar.SetActive(true);
        GameManager.Instance.Player.OnMove = false;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Player.OnMove = true;
        _boss.start = true;
        Destroy(gameObject);
    }
}
