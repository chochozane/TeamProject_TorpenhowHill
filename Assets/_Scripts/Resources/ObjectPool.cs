using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> prefabs;
    [Range(1, 100)] public int poolSize;

    private List<List<GameObject>> objectPools = new List<List<GameObject>>();

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
        List<GameObject> pool = objectPools[index];
        foreach (GameObject obj in pool)
        {
            if (obj == null)
            {
                // �ı��� ��ü�� ó�� (��: ������ϰų� Ǯ���� ����)
                continue; // ����� �ǳʶٱ�� ��
            }
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
