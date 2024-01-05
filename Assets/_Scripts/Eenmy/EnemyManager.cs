using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject playerPrefab;

    void Start()
    {
        // 플레이어를 찾기 (여기에서는 태그를 사용)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // 플레이어가 없으면 새로 생성
        if (player == null)
        {
            SpawnPlayer();
        }
        else
        {
            // 이미 씬에 플레이어가 있다면 여기에서 추가 설정 가능
            // 예: 초기 위치, 초기 상태 등
        }
    }

    void SpawnPlayer()
    {
        // 플레이어를 생성하고 초기 설정을 진행
        GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // 여기에 플레이어의 초기 설정 코드 추가
    }
}
