using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;

    void Start()
    {   

        // ���� �����ϴ� �޼��带 ȣ���մϴ�.
        SpawnEnemy();
    }

    void Update()
    {
            
    }

    void SpawnEnemies()
    {
        Enemy newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.XP = 50;
        newEnemy.Hp = 100;
        newEnemy.AttackCooldown = 2.0f;
        newEnemy.MoveSpeed = 1.5f;
        newEnemy.AttackRange = 3.0f;
        newEnemy.DetectionRange = 30.0f;
    }
}
