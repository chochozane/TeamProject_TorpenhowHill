using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> prefabs;
    public GameObject bossPrefab; // 보스 프리팹에 대한 변수 추가
    [Range(1, 100)] public int poolSize;

    private List<List<GameObject>> objectPools = new List<List<GameObject>>();
    private GameObject bossInstance; // 보스 인스턴스에 대한 변수 추가

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
            bossInstance = Instantiate(bossPrefab); // 보스 인스턴스를 생성하고 변수에 할당
            return bossInstance;
        }

        List<GameObject> pool = objectPools[index];
        foreach (GameObject obj in pool)
        {
            if (obj == null || obj.activeInHierarchy)
            {
                continue;
            }
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);

        // 여기에서 풀에 반환된 몬스터를 재사용하도록 설정
        for (int i = 0; i < objectPools.Count; i++)
        {
            if (objectPools[i].Contains(obj))
            {
                // 몬스터를 풀에 다시 추가
                objectPools[i].Remove(obj);
                objectPools[i].Add(obj);
                break;
            }
        }
    }
}