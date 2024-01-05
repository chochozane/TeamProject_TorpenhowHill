using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 30f; // �÷��̾ �ν��ϴ� ����
    public int speed;
    public int health;
    public int maxHealth;



    private void Awake()
    {

    }

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

                // �� ĳ���͸� �÷��̾� �������� �̵�
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // �� ĳ������ ���⿡ ���� x���� �������� ����
                if (lookDir.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1); // ���� ����
                }
                else if (lookDir.x < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1); // ������ ����
                }
            }
        }
    }
}
