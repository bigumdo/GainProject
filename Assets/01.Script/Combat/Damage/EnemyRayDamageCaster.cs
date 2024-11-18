using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayDamageCaster : DamageCaster
{
    [SerializeField] private float detectionRange = 10f; // ����ĳ��Ʈ �Ÿ�
    [SerializeField] private float checkAngle = 45f; // ���� ���� ���� (�������� ����)
    [SerializeField] private int rayCount = 10; // �� ����ĳ��Ʈ ����
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
            // �� ����ĳ��Ʈ�� ������ ����մϴ�.
            float angle = startAngle + i * angleStep;
            Vector2 direction = Quaternion.Euler(0, 0, angle + transform.localRotation.z) * transform.right;

            //// ����ĳ��Ʈ �߻�
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRange, targetLayer);
            bool isHit = hit.collider != null;
            if (isHit) // ���� �±װ� "Enemy"�� ���
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
