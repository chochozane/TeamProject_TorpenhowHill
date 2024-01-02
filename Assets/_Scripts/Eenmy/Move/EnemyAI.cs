using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 30f; // 플레이어를 인식하는 범위

    private void Update()
    {
        if (player != null)
        {
            // 플레이어와 적 사이의 거리 계산
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // 플레이어를 인식 범위 내에 있을 때만 추적
            if (distanceToPlayer <= detectionRange)
            {
                // 적 캐릭터를 플레이어 방향으로 회전
                Vector2 lookDir = player.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

                // z 축 회전값을 0으로 고정
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);

                // 부드럽게 회전값을 보간
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

                // 적 캐릭터를 플레이어 방향으로 이동
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
