using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int Hp { get; private set; }//ü��
   public int XP { get; private set; }//����ġ

   public float AttackCooldown { get; private set; } //���� ����

   public float MoveSpeed { get; private set; } //�����̴� �ӵ�

   public float AttackRange { get; private set; } //���ݹ���
   public float DetectionRange {  get; private set; }  //�÷��̾� �νĹ���


    public Enemy(int xp, int hp, float attackCooldown, float moveSpeed, float attackRange, float detectionRange)
    {
        XP = xp;
        Hp = hp;
        AttackCooldown = attackCooldown;
        MoveSpeed = moveSpeed;
        AttackRange = attackRange;
        DetectionRange = detectionRange;
    }

}
