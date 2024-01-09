using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy4 : Monster
{
    private void OnEnable()
    {
        if (enemyStats.currentHP <= 0)
        {
            enemyStats.currentHP = 2000;
        }
    }
    protected override void SetMonsterStats()
    {
        base.SetMonsterStats();
        enemyStats = new EnemyStats
        {
            level = 4,
            maxHP = 100000,
            currentHP = 100000,
            Xp = 100000,
            moveSpeed = 2f,
            damageAmount = 100000,
            attackRange = 8

        };
    }
}
