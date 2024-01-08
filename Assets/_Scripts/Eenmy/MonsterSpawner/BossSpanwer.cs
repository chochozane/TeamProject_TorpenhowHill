using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public ObjectPool objectPool;  // ObjectPool 스크립트에 대한 참조
    public int bossPrefabIndex;    // ObjectPool prefabs 목록에서 보스 프리팹의 인덱스
    public float spawnInterval = 180f;  // 보스 스폰 간격(초)

    // 위치 값을 받아오기 위한 외부 변수
    public Transform spawnPosition;  // 외부에서 설정할 위치

    void Start()
    {
        // 보스 주기적 생성을 위한 코루틴 시작
        InvokeRepeating("SpawnBoss", 0f, spawnInterval);
    }

    void SpawnBoss()
    {
        // 풀에서 보스 객체 가져오기
        GameObject boss = objectPool.GetObjectFromPool(bossPrefabIndex);

        if (boss != null)
        {
            // 위치 설정
            if (spawnPosition != null)
            {
                boss.transform.position = spawnPosition.position;
                // 다른 위치 설정을 원한다면 rotation 등을 조절할 수 있습니다.
            }

            // 보스 활성화
            boss.SetActive(true);

            // 일정 시간(예: 10초) 대기한 후 보스를 풀로 반환
            Invoke("ReturnBossToPool", 10f);
        }
    }

    void ReturnBossToPool()
    {
        // 풀로 보스 객체 반환
        objectPool.ReturnObjectToPool(GameObject.FindGameObjectWithTag("Boss"));
    }
}
