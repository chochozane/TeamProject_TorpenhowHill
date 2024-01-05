using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject playerPrefab;

    void Start()
    {
        // �÷��̾ ã�� (���⿡���� �±׸� ���)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // �÷��̾ ������ ���� ����
        if (player == null)
        {
            SpawnPlayer();
        }
        else
        {
            // �̹� ���� �÷��̾ �ִٸ� ���⿡�� �߰� ���� ����
            // ��: �ʱ� ��ġ, �ʱ� ���� ��
        }
    }

    void SpawnPlayer()
    {
        // �÷��̾ �����ϰ� �ʱ� ������ ����
        GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // ���⿡ �÷��̾��� �ʱ� ���� �ڵ� �߰�
    }
}
