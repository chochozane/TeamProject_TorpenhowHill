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

        SetMonsterStats(); // Monster ��ũ��Ʈ���� ��ӹ��� �޼��� ȣ��
        currentHP = maxHP;  // �ִ� ü������ ���� ü���� �ʱ�ȭ�մϴ�.
    }

    private void Update()
    {
        if (player != null)
        {
            // �÷��̾�� �� ������ �Ÿ� ���
            int distanceToPlayer = (int)Vector2.Distance(transform.position, player.position);

            // �÷��̾ �ν� ���� ���� ���� ���� �ൿ
            if (distanceToPlayer <= detectionRange)
            {   

                // �� ĳ���͸� �÷��̾� �������� ȸ��
                Vector2 lookDir = player.position - transform.position;
                int angle = (int)(Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90);

                // �� ĳ���͸� �÷��̾� �������� �̵�
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // �� ĳ������ ���⿡ ���� x���� �������� ����
                if (lookDir.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1); // ���� ����
                }
                else if (lookDir.x < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1); // ������ ����
                }

                // �÷��̾ ���� ���� ���� ���� �� ����
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
        // ���� ���� ���� ����
        Debug.Log("�������� Enemy Attacking!");
    }

    private IEnumerator AttackCooldown()
    {
        // ���� ��ٿ��� ����
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
        

        Destroy(gameObject); // �� ĳ���� �ı� �Ǵ� ��Ȱ��ȭ
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().GainExperience(Xp);
            //collision.gameObject.GetComponent<PlayerStatus>().Damage; ������ �־����
            TakeDamage((int)collision.gameObject.GetComponent<PlayerStatus>().Damage);
        }

    }
    


}
