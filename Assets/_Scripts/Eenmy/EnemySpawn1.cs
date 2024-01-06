using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject monsterPrefab1; // 몬스터 1 프리팹을 Inspector에서 설정
    public GameObject monsterPrefab2; // 몬스터 2 프리팹을 Inspector에서 설정
    public GameObject monsterPrefab3; // 몬스터 3 프리팹을 Inspector에서 설정
    public int numberOfMonsters = 5;    // 생성할 몬스터 수

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        // 몬스터1 소환
        yield return SpawnMonster(monsterPrefab1, new Vector3(10, 10, 0));

        // 몬스터2 소환
        yield return SpawnMonster(monsterPrefab2, new Vector3(0, 0, 0));

        // 몬스터3 소환
        yield return SpawnMonster(monsterPrefab3, new Vector3(-10, -10, 0));

        
    }

    IEnumerator SpawnMonster(GameObject monsterPrefab, Vector3 spawnPosition)
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // 몬스터를 각각의 위치에 생성
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);

            // 생성 간격을 조절하려면 WaitForSeconds의 시간을 조절
            yield return new WaitForSeconds(1);
        }
    }
}
