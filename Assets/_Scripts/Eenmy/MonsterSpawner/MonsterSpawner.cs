using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ���� �������� Inspector���� ����
    public int numberOfMonsters = 5; // ������ ���� ��

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // ���͸� ���� ���� ������ ����
            Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            // ���� ������ �����Ϸ��� WaitForSeconds�� �ð��� ����
            yield return new WaitForSeconds(1.0f);
        }
    }
}

