using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // �÷��̾� �������� Inspector���� ����
    public GameObject monsterPrefab;     // ���� �������� Inspector���� ����
    public int numberOfMonsters = 5;     // ������ ���� ��

    void Start()
    {
        StartCoroutine(SpawnMonsters());
        
    }

    IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            // ���͸� ���� ���� ������ ����
            Instantiate(monsterPrefab, new Vector3(10, 10, 0), Quaternion.identity);

            // ���� ������ �����Ϸ��� WaitForSeconds�� �ð��� ����
            yield return new WaitForSeconds(1);
        }
    }


}
