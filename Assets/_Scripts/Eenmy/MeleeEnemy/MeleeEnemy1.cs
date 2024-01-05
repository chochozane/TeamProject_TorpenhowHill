using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy1 : Monster
{


    private SpriteRenderer characterRenderer;
    private bool canAttack = true;



    private void Start()
    {
        
        characterRenderer = GetComponent < SpriteRenderer>();
        SetMonsterStats();
        currentHP = maxHP;


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

        }
    }
    private void Attack()
    {
        Debug.Log("�������� Enemy Attacking!");
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }



    private void Die()
    {
        // �� ĳ���� �ı� �Ǵ� ��Ȱ��ȭ
        Destroy(gameObject);

        // ������ ���� �÷��̾�� ����ġ�� �ִ� �۾��� �� �� �ֽ��ϴ�.
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
            collision.gameObject.GetComponent<PlayerStatus>().GainExperience(Xp);
            //collision.gameObject.GetComponent<PlayerStatus>().Damage;
            TakeDamage((int)collision.gameObject.GetComponent<PlayerStatus>().Damage);

        }
    }


}
