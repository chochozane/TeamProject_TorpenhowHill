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

    public int detectionRange = 3; // 플레이어를 인식하는 범위
    public int attackRange = 3; // 공격 범위
    public int attackCooldown = 2; // 공격 쿨다운


    protected virtual void Start()
    {
        
        characterRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        SetMonsterStats();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {

             player = players[0].transform;

            // 여기에 플레이어 설정 코드 추가
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
        Debug.Log(damage + "적 받은 데미지");
        Debug.Log(enemyStats.currentHP + "적 현재 체력");
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

        // 다음과 같이 플레이어에게 경험치를 주는 작업을 할 수 있습니다.
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
        // 아이템을 드랍할 로직 추가
        // 여기에서는 간단하게 아이템 프리팹을 생성하여 떨어뜨리는 것으로 가정
        if (itemPrefab != null)
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);

            // 아이템에 대한 추가 설정이 필요하다면 여기에서 설정

            // 예를 들어, 아이템에 Rigidbody2D를 추가하여 떨어뜨릴 수 있습니다.
            Rigidbody2D itemRb = droppedItem.GetComponent<Rigidbody2D>();

        }

    }

}
