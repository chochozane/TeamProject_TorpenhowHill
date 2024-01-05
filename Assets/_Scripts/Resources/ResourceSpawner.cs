using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public ObjectPool objectPool; // ������Ʈ Ǯ���� ���� ObjectPool ��ũ��Ʈ ����
    public Transform spawnPoint; // �ڿ��� ������ ��ġ
    public float spawnRadius = 3f; // ���� ��ġ �ֺ� �ݰ�

    void Start()
    {
        SpawnResource();
    }

    void SpawnResource()
    {
        Vector3 randomPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;

        int randomPrefabIndex = Random.Range(0, objectPool.prefabs.Count);

        // objectPool�� ���� ������Ʈ�� ������
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
