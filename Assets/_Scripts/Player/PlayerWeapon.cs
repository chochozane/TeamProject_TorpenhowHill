using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false; // ���� �������� �����ϴ� �÷���

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void Update()
    {
        WeaponAttack(); // ���� ���� ���� ����
    }

    private void WeaponAttack()
    {
        // "Attack" �ִϸ��̼��� ���� ������ Ȯ���ϰ� isAttacking �÷��װ� false�� ���
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !isAttacking)
        {
            isAttacking = true; // �ߺ��� ���� ������ �����ϱ� ���� �÷��� ����
            ApplyDamage(10); // 10�� ������ ����
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && isAttacking)
        {
            isAttacking = false; // �ִϸ��̼��� ������ �÷��� �ʱ�ȭ
        }
    }

    private void ApplyDamage(int damage)
    {
        // ���⿡ ������ ���� ���� ����
        Debug.Log($"{damage} ������ ����");
    }
}
