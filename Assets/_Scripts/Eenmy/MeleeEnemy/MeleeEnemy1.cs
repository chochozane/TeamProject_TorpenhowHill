using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy1 : Monster
{

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
            damageAmount = 50

        };
    }



}
