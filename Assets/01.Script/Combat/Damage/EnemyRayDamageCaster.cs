using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayDamageCaster : DamageCaster
{
    [SerializeField] private float detectionRange = 10f; // 레이캐스트 거리
    [SerializeField] private float checkAngle = 45f; // 감지 각도 범위 (양쪽으로 퍼짐)
    [SerializeField] private int rayCount = 10; // 쏠 레이캐스트 개수
    private SpriteRenderer _spriteRenderer;

    //[SerializeField] private bool isPlayer;

    private void Awake()
    {
        _spriteRenderer = transform.root.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        //if(isPlayer)
        float angle = _spriteRenderer.flipX ? 0 : 180;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    public override bool DamageCast()
    {
        float startAngle = -checkAngle / 2;
        float angleStep = checkAngle / (rayCount - 1);


        for (int i = 0; i < rayCount; i++)
        {
            // 각 레이캐스트의 각도를 계산합니다.
            float angle = startAngle + i * angleStep;
            Vector2 direction = Quaternion.Euler(0, 0, angle + transform.localRotation.z) * transform.right;

            //// 레이캐스트 발사
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRange, targetLayer);
            bool isHit = hit.collider != null;
            if (isHit) // 적의 태그가 "Enemy"일 경우
            {
                if (hit.collider.TryGetComponent<IDamage>(out IDamage health))
                {
                    int damage = _owner.Stat.GetDamage();

                    health.ApplyDamage(damage);
                }
                return isHit;
            }

            Debug.DrawRay(transform.position, direction * detectionRange, Color.red);
        }
        return false;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float startAngle = -checkAngle / 2;
        float angleStep = checkAngle / (rayCount - 1);
        for (int i = 0; i < rayCount; i++)
        {
            float angle = startAngle + i * angleStep;
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.right;
            Gizmos.DrawRay(transform.position, direction * detectionRange);
        }
    }
#endif
}
