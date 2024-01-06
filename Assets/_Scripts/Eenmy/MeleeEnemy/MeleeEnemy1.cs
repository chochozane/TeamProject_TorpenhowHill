using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy1 : Monster
{

    private SpriteRenderer characterRenderer;
    private bool canAttack = true;
    Animator anim;
    public GameObject itemPrefab;

    protected override void Start()
    {
        base.Start();
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
        Debug.Log("���� ���Ŀ�");
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
 

        DropItem();
        // ������ ���� �÷��̾�� ����ġ�� �ִ� �۾��� �� �� �ֽ��ϴ�.
        if (player != null)
        {
            PlayerStatus playerStatus = player.GetComponent<PlayerStatus>();
            if (playerStatus != null)
            {
                playerStatus.GainExperience(Xp);
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            TakeDamage((int)collision.gameObject.GetComponent<PlayerWeapon>().weaponDamage);
            Debug.Log((int)collision.gameObject.GetComponent<PlayerWeapon>().weaponDamage);
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
            if (itemRb != null)
            {
                // �������� ����߸��� ����
                itemRb.AddForce(Vector2.up * 200f);
                itemRb.AddForce(Vector2.right * Random.Range(-100f, 100f));
            }
        }
    }
}
