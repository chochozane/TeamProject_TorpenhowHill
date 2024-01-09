using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy3 : Monster
{
    private void OnEnable()
    {
        if (enemyStats.currentHP <= 0)
        {
            enemyStats.currentHP = 900;
        }
    }
    protected override void SetMonsterStats()
    {
        base.SetMonsterStats();
        enemyStats = new EnemyStats
        {
            level = 3,
            maxHP = 900,
            currentHP = 900,
            Xp = 250000,
            moveSpeed = 1.5f,
            damageAmount = 3200,
            
        };
    }
}
