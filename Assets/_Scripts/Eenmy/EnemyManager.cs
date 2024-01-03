using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;

    void Start()
    {
        // 적을 생성하는 메서드를 호출합니다.
        SpawnEnemies();
    }

    void Update()
    {
            
    }

    void SpawnEnemies()
    {
        // 근접 적 생성
        GameObject meleeEnemy = Instantiate(meleeEnemyPrefab, transform.position, Quaternion.identity);
        meleeEnemy.GetComponent<Move>().moveSpeed = 3f;
        meleeEnemy.GetComponent<EnemyStats>().health = 100;
        meleeEnemy.GetComponent<EnemyStats>().attackDamage = 20;

        // 원거리 적 생성
        GameObject rangedEnemy = Instantiate(rangedEnemyPrefab, transform.position, Quaternion.identity);
        rangedEnemy.GetComponent<Move>().moveSpeed = 5f;
        rangedEnemy.GetComponent<EnemyStats>().health = 80;
        rangedEnemy.GetComponent<EnemyStats>().attackDamage = 15;
    }
}
