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
        // Enemy Ŭ������ �ν��Ͻ� ���� �� �ʱ�ȭ
        Enemy enemyInstance = new Enemy(xp: 50, hp: 100, attackCooldown: 2.0f, moveSpeed: 1.5f, attackRange: 3.0f, detectionRange: 30.0f);

        // Enemy�� ������ ����
        Debug.Log($"Enemy HP: {enemyInstance.Hp}");
        Debug.Log($"Enemy XP: {enemyInstance.XP}");

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

        Hp -= (int)damage;

        if (Hp <= 0)
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

