using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy2 : Monster
{
    private void OnEnable()
    {
        if (enemyStats.currentHP <= 0)
        {
            enemyStats.currentHP = 600;
        }
    }

    protected override void SetMonsterStats()
    {
        base.SetMonsterStats();
        enemyStats = new EnemyStats
        {
            level = 2,
            maxHP = 600,
            currentHP = 600,
            Xp = 5000,
            moveSpeed = 1.5f,
            damageAmount = 400,
            attackRange = 5
        };
    }

}
