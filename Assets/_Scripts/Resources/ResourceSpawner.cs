using System.Collections;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public ObjectPool objectPool;
    public Transform spawnPoint;
    public float spawnRadius = 3f;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            SpawnResource();
        }
    }

    void SpawnResource()
    {
        Vector3 randomPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;

        int randomPrefabIndex = Random.Range(0, objectPool.prefabs.Count);

        GameObject resource = objectPool.GetObjectFromPool(randomPrefabIndex);

        if (resource != null)
        {
            resource.transform.position = randomPosition;
            resource.SetActive(true);
        }
    }
}
