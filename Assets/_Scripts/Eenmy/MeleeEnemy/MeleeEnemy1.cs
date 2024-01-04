using System.Collections;
using UnityEngine;

public class MeleeEnemy1 : Monster
{


    private SpriteRenderer characterRenderer;
    private bool canAttack = true;



    private void Start()
    {
        characterRenderer = GetComponent < SpriteRenderer>();
        SetMonsterStats(); // Monster ��ũ��Ʈ���� ��ӹ��� �޼��� ȣ��
    }

    private void Update()
    {
        if (player != null)
        {
            // �÷��̾�� �� ������ �Ÿ� ���
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // �÷��̾ �ν� ���� ���� ���� ���� �ൿ
            if (distanceToPlayer <= detectionRange)
            {
                // �� ĳ���͸� �÷��̾� �������� ȸ��
                Vector2 lookDir = player.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

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

    public override void TakeDamage(float damage)
    {
        maxHP -= (int)damage;

        if (maxHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStatus.Instance.GainExperience(Xp);

        Destroy(gameObject); // �� ĳ���� �ı� �Ǵ� ��Ȱ��ȭ
    }
}
