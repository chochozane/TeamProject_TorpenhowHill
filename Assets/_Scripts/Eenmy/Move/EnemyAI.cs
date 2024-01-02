using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 30f; // �÷��̾ �ν��ϴ� ����

    private void Update()
    {
        if (player != null)
        {
            // �÷��̾�� �� ������ �Ÿ� ���
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // �÷��̾ �ν� ���� ���� ���� ���� ����
            if (distanceToPlayer <= detectionRange)
            {
                // �� ĳ���͸� �÷��̾� �������� ȸ��
                Vector2 lookDir = player.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

                // z �� ȸ������ 0���� ����
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);

                // �ε巴�� ȸ������ ����
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

                // �� ĳ���͸� �÷��̾� �������� �̵�
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
