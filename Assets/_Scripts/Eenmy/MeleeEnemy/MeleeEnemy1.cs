using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy1 : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 30f; // �÷��̾ �ν��ϴ� ����
    public float attackRange = 3f; // ���� ����
    public float moveSpeed = 1.5f;
    public float attackCooldown = 2f; // ���� ��ٿ�


    private SpriteRenderer characterRenderer;
    private bool canAttack = true;

    public int Health = 100;
    public int XP = 50;

    private void Start()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
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

    private System.Collections.IEnumerator AttackCooldown()
    {
        // ���� ��ٿ��� ����
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
        // ���⿡ �� ĳ���� ��� ó�� �ڵ� �߰�


        Destroy(gameObject); // �� ĳ���� �ı� �Ǵ� ��Ȱ��ȭ
    }
}
