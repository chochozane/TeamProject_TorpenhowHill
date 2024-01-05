using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject playerPrefab;      // 플레이어 프리팹을 Inspector에서 설정
    public GameObject monsterPrefab;     // 몬스터 프리팹을 Inspector에서 설정
    public int numberOfMonsters = 5;     // 생성할 몬스터 수

    void Start()
    {
        StartCoroutine(SpawnMonsters());
        SpawnPlayer();
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // 몬스터를 현재 스폰 지점에 생성
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            // 생성 간격을 조절하려면 WaitForSeconds의 시간을 조절
            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnPlayer()
    {
        // 플레이어를 생성하고 초기 설정을 진행
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        // 여기에 플레이어의 초기 설정 코드 추가
    }
}
