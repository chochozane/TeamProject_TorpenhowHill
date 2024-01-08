using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy_Boss : Monster
{
    protected override void SetMonsterStats()
    {
        base.SetMonsterStats();
        enemyStats = new EnemyStats
        {
            level = 4,
            maxHP = 2000,
            currentHP = 2000,
            Xp = 500000,
            moveSpeed = 2f,
            damageAmount = 50

        };
    }
}
