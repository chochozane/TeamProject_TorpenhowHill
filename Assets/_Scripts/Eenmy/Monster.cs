using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    protected struct EnemyStats
    {
        public int level;
        public int maxHP;
        public int Xp;
        public float moveSpeed;
        public int damageAmount;
        public int currentHP;
    }



    protected EnemyStats enemyStats;

    private SpriteRenderer characterRenderer;
    private bool canAttack = true;
    Animator anim;
    public GameObject itemPrefab;




    public Transform player;

    public int detectionRange = 3; // �÷��̾ �ν��ϴ� ����
    public int attackRange = 3; // ���� ����
    public int attackCooldown = 2; // ���� ��ٿ�


    protected virtual void Start()
    {
        
        characterRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        SetMonsterStats();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {

             player = players[0].transform;

            // ���⿡ �÷��̾� ���� �ڵ� �߰�
        }
    }

    protected virtual void SetMonsterStats()
    {

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

                transform.position = Vector2.MoveTowards(transform.position, player.position, enemyStats.moveSpeed * Time.deltaTime);

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
        enemyStats.currentHP -= (int)damage;
        Debug.Log(damage + "�� ���� ������");
        Debug.Log(enemyStats.currentHP + "�� ���� ü��");
        if (enemyStats.currentHP <= 0)
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
        return enemyStats.damageAmount;

    }

    private IEnumerator AttackCooldown()
    {

        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

    }

    private void Die()
    {
        DropItem();

        // ������ ���� �÷��̾�� ����ġ�� �ִ� �۾��� �� �� �ֽ��ϴ�.
        if (player != null)
        {
            PlayerStatus playerStatus = player.GetComponent<PlayerStatus>();
            if (playerStatus != null)
            {
                playerStatus.GainExperience(enemyStats.Xp);
            }
        }

        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            collision.gameObject.GetComponent<PlayerWeapon>().SetDamage();
            TakeDamage((int)collision.gameObject.GetComponent<PlayerWeapon>().WeaponDamage);
            Debug.Log((int)collision.gameObject.GetComponentInChildren<PlayerWeapon>().WeaponDamage);
        }
    }

    private void DropItem()
    {
        // �������� ����� ���� �߰�
        // ���⿡���� �����ϰ� ������ �������� �����Ͽ� ����߸��� ������ ����
        if (itemPrefab != null)
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);

            // �����ۿ� ���� �߰� ������ �ʿ��ϴٸ� ���⿡�� ����

            // ���� ���, �����ۿ� Rigidbody2D�� �߰��Ͽ� ����߸� �� �ֽ��ϴ�.
            Rigidbody2D itemRb = droppedItem.GetComponent<Rigidbody2D>();

        }

    }

}
