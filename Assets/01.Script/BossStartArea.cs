using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartArea : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private GameObject startPillar;


    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (TryGetComponent(out Player player))
        {
            startPillar.SetActive(true);
        }

    }
}
