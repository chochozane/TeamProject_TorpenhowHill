using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public ObjectPool objectPool;  // ObjectPool ��ũ��Ʈ�� ���� ����
    public int bossPrefabIndex;    // ObjectPool prefabs ��Ͽ��� ���� �������� �ε���
    public float spawnInterval = 180f;  // ���� ���� ����(��)

    // ��ġ ���� �޾ƿ��� ���� �ܺ� ����
    public Transform spawnPosition;  // �ܺο��� ������ ��ġ

    void Start()
    {
        // ���� �ֱ��� ������ ���� �ڷ�ƾ ����
        InvokeRepeating("SpawnBoss", 0f, spawnInterval);
    }

    void SpawnBoss()
    {
        // Ǯ���� ���� ��ü ��������
        GameObject boss = objectPool.GetObjectFromPool(bossPrefabIndex);

        if (boss != null)
        {
            // ��ġ ����
            if (spawnPosition != null)
            {
                boss.transform.position = spawnPosition.position;
                // �ٸ� ��ġ ������ ���Ѵٸ� rotation ���� ������ �� �ֽ��ϴ�.
            }

            // ���� Ȱ��ȭ
            boss.SetActive(true);

            // ���� �ð�(��: 10��) ����� �� ������ Ǯ�� ��ȯ
            Invoke("ReturnBossToPool", 10f);
        }
    }

    void ReturnBossToPool()
    {
        // Ǯ�� ���� ��ü ��ȯ
        objectPool.ReturnObjectToPool(GameObject.FindGameObjectWithTag("Boss"));
    }
}
