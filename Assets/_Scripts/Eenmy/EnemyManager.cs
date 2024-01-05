using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject playerPrefab;      // �÷��̾� �������� Inspector���� ����
    public GameObject monsterPrefab;     // ���� �������� Inspector���� ����
    public int numberOfMonsters = 5;     // ������ ���� ��

    void Start()
    {
        StartCoroutine(SpawnMonsters());
        SpawnPlayer();
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

    void SpawnPlayer()
    {
        // �÷��̾ �����ϰ� �ʱ� ������ ����
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        // ���⿡ �÷��̾��� �ʱ� ���� �ڵ� �߰�
    }
}
