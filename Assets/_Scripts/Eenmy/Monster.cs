using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int level = 1;
    public int maxHP;
    public int Xp;
    public Transform player;
    public float detectionRange = 30f; // �÷��̾ �ν��ϴ� ����
    public float attackRange = 3f; // ���� ����
    public float moveSpeed = 1.5f;
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
                maxHP = 1000;
                Xp = 100;
                break;
            case 2:
                maxHP = 5000;
                Xp = 1000;
                break;
            case 3:
                maxHP = 1000000;
                Xp = 100000;
                break;
            default:
                Debug.LogWarning("Invalid monster level!");
                break;
        }
    }


    public virtual void TakeDamage(float damage)
    {
        maxHP -= (int)damage;

        if (maxHP <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        PlayerStatus.Instance.GainExperience(Xp);
        Destroy(gameObject);

    }
}
