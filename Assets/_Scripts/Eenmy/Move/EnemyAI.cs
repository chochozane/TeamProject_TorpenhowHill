using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 30f; // 플레이어를 인식하는 범위
    public int speed;
    public int health;
    public int maxHealth;



    private void Awake()
    {

    }

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

                // 적 캐릭터를 플레이어 방향으로 이동
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // 적 캐릭터의 방향에 따라 x축을 기준으로 반전
                if (lookDir.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1); // 원래 방향
                }
                else if (lookDir.x < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1); // 반전된 방향
                }
            }
        }
    }
}
