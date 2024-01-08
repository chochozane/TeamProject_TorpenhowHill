using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> prefabs;
    public GameObject bossPrefab; // ���� �����տ� ���� ���� �߰�
    [Range(1, 100)] public int poolSize;

    private List<List<GameObject>> objectPools = new List<List<GameObject>>();
    private GameObject bossInstance; // ���� �ν��Ͻ��� ���� ���� �߰�

    private bool bossSpawned = false;

    void Start()
    {
        InitializePools();
    }

    void InitializePools()
    {
        foreach (GameObject prefab in prefabs)
        {
            List<GameObject> pool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                pool.Add(obj);
            }
            objectPools.Add(pool);
        }
    }


    public GameObject GetObjectFromPool(int index)
    {
        if (bossPrefab != null && !bossSpawned)
        {
            bossSpawned = true;
            bossInstance = Instantiate(bossPrefab); // ���� �ν��Ͻ��� �����ϰ� ������ �Ҵ�

            // ������ Ǯ���� ���� �� �ʱ�ȭ
            Monster bossMonster = bossInstance.GetComponent<Monster>();
            if (bossMonster != null)
            {
                bossMonster.InitializeMonster();
            }

            return bossInstance;
        }

        List<GameObject> pool = objectPools[index];
        foreach (GameObject obj in pool)
        {
            if (obj == null || obj.activeInHierarchy)
            {
                continue;
            }

            // ���Ͱ� Ǯ���� ���� �� �ʱ�ȭ
            Monster monster = obj.GetComponent<Monster>();
            if (monster != null)
            {
                monster.InitializeMonster();
            }

            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);

        // ���⿡�� Ǯ�� ��ȯ�� ���͸� �����ϵ��� ����
        for (int i = 0; i < objectPools.Count; i++)
        {
            if (objectPools[i].Contains(obj))
            {
                // ���͸� Ǯ�� �ٽ� �߰�
                objectPools[i].Remove(obj);
                objectPools[i].Add(obj);
                break;
            }
        }
    }
}
