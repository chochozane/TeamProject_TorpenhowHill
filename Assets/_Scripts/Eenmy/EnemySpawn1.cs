using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject monsterPrefab1; // ���� 1 �������� Inspector���� ����
    public GameObject monsterPrefab2; // ���� 2 �������� Inspector���� ����
    public GameObject monsterPrefab3; // ���� 3 �������� Inspector���� ����
    public int numberOfMonsters = 5;    // ������ ���� ��

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        // ����1 ��ȯ
        yield return SpawnMonster(monsterPrefab1, new Vector3(10, 10, 0));

        // ����2 ��ȯ
        yield return SpawnMonster(monsterPrefab2, new Vector3(0, 0, 0));

        // ����3 ��ȯ
        yield return SpawnMonster(monsterPrefab3, new Vector3(-10, -10, 0));

        
    }

    IEnumerator SpawnMonster(GameObject monsterPrefab, Vector3 spawnPosition)
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // ���͸� ������ ��ġ�� ����
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);

            // ���� ������ �����Ϸ��� WaitForSeconds�� �ð��� ����
            yield return new WaitForSeconds(1);
        }
    }
}
