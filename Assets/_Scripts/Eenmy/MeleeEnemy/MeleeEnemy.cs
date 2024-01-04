using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private SpriteRenderer characterRenderer;
    private bool canAttack = true;

    private Transform player;
    private int Hp = 100;
    private int Xp { get;}
    private float detectionRange { get; }
    private float attackRange { get; }

    private float attackCooldown { get; }

    private float moveSpeed { get; }

    private void Start()
    {
        // Enemy 클래스의 인스턴스 생성 및 초기화
        Enemy enemyInstance = new Enemy(xp: 50, hp: 100, attackCooldown: 2.0f, moveSpeed: 1.5f, attackRange: 3.0f, detectionRange: 30.0f);

        // Enemy의 정보에 접근
        Debug.Log($"Enemy HP: {enemyInstance.Hp}");
        Debug.Log($"Enemy XP: {enemyInstance.XP}");

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
        // 근접 공격 로직 구현
        Debug.Log("근접공격 Enemy Attacking!");
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

        Hp -= (int)damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 여기에 적 캐릭터 사망 처리 코드 추가


        Destroy(gameObject); // 적 캐릭터 파괴 또는 비활성화
    }
}

