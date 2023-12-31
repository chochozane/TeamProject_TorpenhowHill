using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy1 : Monster
{
    private void OnEnable()
    {
        if (enemyStats.currentHP <= 0)
        {
            enemyStats.currentHP = 300;
        }
    }
    protected override void SetMonsterStats()
    {
        base.SetMonsterStats();
        enemyStats = new EnemyStats
        {
            level = 1,
            maxHP = 300,
            currentHP = 300,
            Xp = 100,
            moveSpeed = 1.5f,
            damageAmount = 50,
            attackRange =5

        };
    }



}
