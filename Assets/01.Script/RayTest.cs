using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public float detectionRange = 10f; // 레이캐스트 거리
    public float detectionAngle = 45f; // 감지 각도 범위 (양쪽으로 퍼짐)
    public int rayCount = 10; // 쏠 레이캐스트 개수

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
            // 각 레이캐스트의 각도를 계산합니다.
            float angle = startAngle + i * angleStep;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * transform.right;

            //// 레이캐스트 발사
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRange);
            //if (hit.collider != null && hit.collider.CompareTag("Enemy")) // 적의 태그가 "Enemy"일 경우
            //{
            //    Debug.Log("적 감지: " + hit.collider.name);
            //    // 감지된 적에 대한 처리 추가
            //}

            //// 디버그 라인 그리기
            Debug.DrawRay(transform.position, direction * detectionRange, Color.red);
        }
    }

}
