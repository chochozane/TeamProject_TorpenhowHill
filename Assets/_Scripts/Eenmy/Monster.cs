using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int level  = 1;
    public int maxHP;
    public int Xp;
    public float moveSpeed;
    public int damageAmount;

    protected int currentHP;

    public Transform player;

    public int detectionRange = 15; // �÷��̾ �ν��ϴ� ����
    public float attackRange = 3f; // ���� ����
    public float attackCooldown = 2f; // ���� ��ٿ�
    

    void Start()
    {
        SetMonsterStats();
    }

    protected virtual void SetMonsterStats()
    {
        switch (level)
        {
            case 1:
                maxHP = 300;
                Xp = 100;
                moveSpeed = 1.5f;
                damageAmount = 50;
                break;
            case 2:
                maxHP = 600;
                Xp = 5000;
                moveSpeed = 1.75f;
                damageAmount = 400;
                break;
            case 3:
                maxHP = 900;
                Xp = 250000;
                moveSpeed = 1.9f;
                damageAmount = 3200;
                break;
            default:
                Debug.LogWarning("Level�� �Է����ּ���!");
                break;
        }
        currentHP = maxHP;  // �ʱ�ȭ �� ���� ü���� �ִ� ü������ ����
    }


    public virtual void TakeDamage(int damage)
    {
        currentHP -= (int)damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        PlayerStatus.Instance.GainExperience(Xp);
        Destroy(gameObject);
    }

    //void DealDamage()
    //{
    //    PlayerStatus player = FindObjectOfType<PlayerStatus>();
    //    if (player != null)
    //    {
    //        player.TakeDamage(damageAmount);
    //    }
    //}
}
