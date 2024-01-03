using UnityEngine;

public class RangedEnemy1 : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 30f; // 플레이어를 인식하는 범위
    public float attackRange = 15f; // 공격 범위
    public float moveSpeed = 3f;
    public float attackCooldown = 2f; // 공격 쿨다운


    private SpriteRenderer characterRenderer;
    private bool canAttack = true;

    public int Health = 50;
    public int XP = 25;

    private void Start()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player != null)
        {
            // 플레이어와 적 사이의 거리 계산
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // 플레이어를 인식 범위 내에 있을 때만 행동
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

                // 플레이어가 공격 범위 내에 있을 때 공격
                if (distanceToPlayer <= attackRange && canAttack)
                {
                    Attack();
                    StartCoroutine(AttackCooldown());
                }
            }
        }
    }

    private void Attack()
    {
        // 원거리 공격 로직 구현
        Debug.Log("원거리 공격");
    }

    private System.Collections.IEnumerator AttackCooldown()
    {
        // 공격 쿨다운을 설정
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void TakeDamage(float damage)
    {

        Health -= (int)damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 여기에 적 캐릭터 사망 처리 코드 추가

        // 플레이어에게 경험치 전달
        //PlayerController playerController = player.GetComponent<PlayerController>();
        //if (playerController != null)
        //{
        //    playerController.GainXP(XP);
        //}

        Destroy(gameObject); // 적 캐릭터 파괴 또는 비활성화
    }
}
