using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public float detectionRange = 10f; // ����ĳ��Ʈ �Ÿ�
    public float detectionAngle = 45f; // ���� ���� ���� (�������� ����)
    public int rayCount = 10; // �� ����ĳ��Ʈ ����

    void Start()
    {
        DetectEnemies();
    }

    void DetectEnemies()
    {
        float startAngle = -detectionAngle / 2;
        float angleStep = detectionAngle / (rayCount - 1);


        for (int i = 0; i < rayCount; i++)
        {
            // �� ����ĳ��Ʈ�� ������ ����մϴ�.
            float angle = startAngle + i * angleStep;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * transform.right;

            //// ����ĳ��Ʈ �߻�
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRange);
            //if (hit.collider != null && hit.collider.CompareTag("Enemy")) // ���� �±װ� "Enemy"�� ���
            //{
            //    Debug.Log("�� ����: " + hit.collider.name);
            //    // ������ ���� ���� ó�� �߰�
            //}

            //// ����� ���� �׸���
            Debug.DrawRay(transform.position, direction * detectionRange, Color.red);
        }
    }

}
