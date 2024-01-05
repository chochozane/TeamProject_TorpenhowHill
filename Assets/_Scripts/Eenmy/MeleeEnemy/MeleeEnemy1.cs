using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy1 : Monster
{

    private SpriteRenderer characterRenderer;
    private bool canAttack = true;
    Animator anim;


    private void Start()
    {
        
        characterRenderer = GetComponent < SpriteRenderer>();
        SetMonsterStats();
        currentHP = maxHP;
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        if (player != null)
        {
            int distanceToPlayer = (int)Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                Vector2 lookDir = player.position - transform.position;
                int angle = (int)(Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90);

                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                if (lookDir.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (lookDir.x < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                if (distanceToPlayer <= attackRange && canAttack)
                {
                    Attack();
                    StartCoroutine(AttackCooldown());
                }
            }
        }
    }
    public virtual void TakeDamage(int damage)
    {
        currentHP -= (int)damage;

        if (currentHP <= 0)
        {
            Die();

        }
        else
        {
            anim.SetTrigger("Hit");
        }
    }
    public int Attack()
    {
        return damageAmount;
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }



    private void Die()
    {
        // 적 캐릭터 파괴 또는 비활성화
        Destroy(gameObject);
        // 아이템 드랍 로직 추가
        //DropItem();

        // 다음과 같이 플레이어에게 경험치를 주는 작업을 할 수 있습니다.
        if (player != null)
        {
            PlayerStatus playerStatus = player.GetComponent<PlayerStatus>();
            if (playerStatus != null)
            {
                playerStatus.GainExperience(Xp);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player != null) 
            {
                collision.gameObject.GetComponent<PlayerStatus>().GainExperience(Xp);

                TakeDamage((int)collision.gameObject.GetComponent<PlayerStatus>().Damage);
                //Debug.Log((int)collision.gameObject.GetComponent<PlayerStatus>().Damage);
            }
        }
    }

 

    //    private void DropItem()
    //{
    //    // 아이템을 드랍할 로직 추가
    //    // 여기에서는 간단하게 아이템 프리팹을 생성하여 떨어뜨리는 것으로 가정
    //    if (itemPrefab != null)
    //    {
    //        GameObject droppedItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
    //        // 아이템에 대한 추가 설정이 필요하다면 여기에서 설정
    //    }
    //}
}
