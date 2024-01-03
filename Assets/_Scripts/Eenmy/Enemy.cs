using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int Hp { get; private set; }//체력
   public int XP { get; private set; }//경험치

   public float AttackCooldown { get; private set; } //공격 간격

   public float MoveSpeed { get; private set; } //움직이는 속도

   public float AttackRange { get; private set; } //공격범위
   public float DetectionRange {  get; private set; }  //플레이어 인식범위


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
