using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRenderer : AgentRenderer
{
    private SpriteRenderer spriteRenderer;
    private Enemy _Enemy;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _Enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (!_Enemy.MovementCompo.IsGorund)
            return;
        if(GameManager.Instance.Player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
            spriteRenderer.flipX = false;
    }
}
