using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // �÷��̾� �̵� �ӵ�
    [SerializeField] private float attackRange = 2f; // ���� ����
    [SerializeField] private float attackSpeed = 1f; // �ʴ� ���� Ƚ��

    private Animator animator;
    Vector3 mousePos, transPos, targetPos;
    private Inventory inventory;
    private bool NPCTalkOn = false;
    private bool isRunning = false;
    private bool isCollidingWithNPC = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            CalTargetPos();
            if (!isRunning)
            {
                isRunning = true;
                animator.SetBool("Run", true);
            }
        }
        if (inventory.inventoryWindow == false) 
        {
            FlipSprite(); // ��������Ʈ ������
            MoveToTarget(); // Ÿ�� ��ġ�� �̵�        
            AttackButton();
            InteractWithNPC();
        }
    }

    private void CalTargetPos()
    {
        mousePos = Input.mousePosition; // ���콺 ��ġ ��������
        transPos = Camera.main.ScreenToWorldPoint(mousePos); // ���콺 ��ġ�� ���� ����Ʈ�� ��ȯ
        targetPos = new Vector3(transPos.x, transPos.y, 0); // z ��ǥ�� 0���� ����
    }
    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed); // Move to target location
        if (Vector3.Distance(transform.position, targetPos) < 0.1f) // Check if close to target
        {
            if (isRunning)
            {
                isRunning = false;
                animator.SetBool("Run", false); // Stop running
            }
        }
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

    private void AttackButton()
    {
        if (Input.GetKeyDown(KeyCode.A)) // A Ű�� �� �����ӿ� ���ȴ��� Ȯ��
        {
            //���� ���� ������ ������ Weapon�� ����~
            animator.SetTrigger("Attack"); // ���� �ִϸ��̼� ����

        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            isCollidingWithNPC = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            isCollidingWithNPC = false;
        }
    }

    private void InteractWithNPC()
    {
        if (isCollidingWithNPC)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("��ȣ�ۿ�");
            }
        }
    }


}