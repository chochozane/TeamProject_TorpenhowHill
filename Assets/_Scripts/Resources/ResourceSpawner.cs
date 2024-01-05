using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public ObjectPool objectPool; // 오브젝트 풀링을 위한 ObjectPool 스크립트 참조
    public Transform spawnPoint; // 자원이 생성될 위치
    public float spawnRadius = 3f; // 스폰 위치 주변 반경

    void Start()
    {
        SpawnResource();
    }

    void SpawnResource()
    {
        Vector3 randomPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;

        int randomPrefabIndex = Random.Range(0, objectPool.prefabs.Count);

        // objectPool를 통해 오브젝트를 가져옴
        GameObject resource = objectPool.GetObjectFromPool(randomPrefabIndex);

        if (resource != null)
        {
            resource.transform.position = randomPosition;
            resource.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Resource not assigned or available in the pool!");
        }
    }
}
