using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy1 : Monster
{


    private SpriteRenderer characterRenderer;
    private bool canAttack = true;
    private int currentHP;


    private void Start()
    {
        characterRenderer = GetComponent<SpriteRenderer>();

        SetMonsterStats(); // Monster 스크립트에서 상속받은 메서드 호출
        currentHP = maxHP;  // 최대 체력으로 현재 체력을 초기화합니다.
    }

    private void Update()
    {
        if (player != null)
        {
            // 플레이어와 적 사이의 거리 계산
            int distanceToPlayer = (int)Vector2.Distance(transform.position, player.position);

            // 플레이어를 인식 범위 내에 있을 때만 행동
            if (distanceToPlayer <= detectionRange)
            {   

                // 적 캐릭터를 플레이어 방향으로 회전
                Vector2 lookDir = player.position - transform.position;
                int angle = (int)(Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90);

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

    private IEnumerator AttackCooldown()
    {
        // 공격 쿨다운을 설정
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public override void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0f)
        {
            
            Die();
        }
    }

    private void Die()
    {
        

        Destroy(gameObject); // 적 캐릭터 파괴 또는 비활성화
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().GainExperience(Xp);
            //collision.gameObject.GetComponent<PlayerStatus>().Damage; 변수에 넣어놓기
            TakeDamage((int)collision.gameObject.GetComponent<PlayerStatus>().Damage);
        }

    }
    


}
