using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // �÷��̾� �̵� �ӵ�
    [SerializeField] private float attackRange = 2f; // ���� ����
    [SerializeField] private float attackSpeed = 1f; // �ʴ� ���� Ƚ��

    Vector3 mousePos, transPos, targetPos;
    private GameObject targetEnemy = null;
    private float lastAttackTime;
    private bool NPCTalkOn = false;

    private void Start()
    {
        AttackButton(); // ���� ��ư ���� ����
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalTargetPos(); // Ÿ�� ��ġ ���
        }
        MoveToTarget(); // Ÿ�� ��ġ�� �̵�
        FlipSprite(); // ��������Ʈ ������
        EffectButton(); // 'F' ��ư���� ��ȣ�ۿ� (��: NPC ��ȭ)
        
    }

    private void CalTargetPos()
    {
        mousePos = Input.mousePosition; // ���콺 ��ġ ��������
        transPos = Camera.main.ScreenToWorldPoint(mousePos); // ���콺 ��ġ�� ���� ����Ʈ�� ��ȯ
        targetPos = new Vector3(transPos.x, transPos.y, 0); // z ��ǥ�� 0���� ����
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed); // Ÿ�� ��ġ�� �̵�
    }

    private void FlipSprite()
    {
        // ���� �̵��� �߿����� Ȯ��
        if (Mathf.Abs(targetPos.x - transform.position.x) > 0.01f)
        {
            // x���� �߽����� ��������Ʈ ������
            transform.localScale = new Vector3(-Mathf.Sign(targetPos.x - transform.position.x), 1f, 1f);
        }
    }

    private void EffectButton()
    {
        if (Input.GetKey(KeyCode.F)) // F Ű�� ���ȴ��� Ȯ��
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f); // ���� ��ġ���� �ݰ� 1f ���� ��� �ݶ��̴� ����
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("NPC")) // �ݶ��̴��� �±װ� 'NPC'���� Ȯ��
                {
                    NPCTalkOn = true; // NPC�� ���������Ƿ� NPCTalkOn�� true�� ����
                    break; // NPC�� ã������ �� �̻� �ٸ� �ݶ��̴��� Ȯ���� �ʿ� ����
                }
            }
        }
    }

    private void AttackButton()
    {
        if (Input.GetMouseButton(0)) // ���� ���콺 ��ư Ŭ�� Ȯ��
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("enemy"))
            {
                targetEnemy = hit.collider.gameObject; // Ŭ���� ���� Ÿ������ ����
            }
        }

        if (targetEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.transform.position);

            if (distanceToEnemy <= attackRange)
            {
                if (Time.time - lastAttackTime >= 1f / attackSpeed)
                {
                    Attack(); // ���� ����
                    lastAttackTime = Time.time; // ������ ���� �ð� ������Ʈ
                }
            }
            else
            {
                MoveToTarget(targetEnemy.transform.position); // ������ �̵�
            }
        }
    }

    private void Attack()
    {
        // ���⿡ ���� ���� ���� (��: �� ü�� ����)
    }

    private void MoveToTarget(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed); // Ÿ�� ��ġ�� �̵�
    }
}