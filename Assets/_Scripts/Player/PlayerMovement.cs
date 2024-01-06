using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // 플레이어 이동 속도
    [SerializeField] private float attackRange = 2f; // 공격 범위
    [SerializeField] private float attackSpeed = 1f; // 초당 공격 횟수
    Vector3 mousePos, transPos, targetPos;
    private Animator animator;
    private PlayerStatus playerStatus;
    private Inventory inventory;
    private bool NPCTalkOn = false;
    private bool isRunning = false;
    private bool isCollidingWithNPC = false;
    private bool canMove = true;

    private void Start()
    {
        PlayerWeapon Weapon = new PlayerWeapon();
        animator = GetComponentInChildren<Animator>();
        //inventory 땡겨!
        inventory = GetComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            CalTargetPos();
            if (!isRunning)
            {
                isRunning = true;
                animator.SetBool("Run", true);
            }
        }
        if (UIManager.isGamePaused == false)
        {
            if (canMove) // Check if player can move
            {
                FlipSprite(); // 스프라이트 뒤집기
                MoveToTarget(); // 타겟 위치로 이동        
            }
            if (!canMove && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                EnableMovement();
            }
            AttackButton();
            InteractWithNPC();
        }
    }

    private void CalTargetPos()
    {
        mousePos = Input.mousePosition; // 마우스 위치 가져오기
        transPos = Camera.main.ScreenToWorldPoint(mousePos); // 마우스 위치를 월드 포인트로 변환
        targetPos = new Vector3(transPos.x, transPos.y, 0); // z 좌표는 0으로 설정
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
        // 수평 이동이 중요한지 확인
        if (Mathf.Abs(targetPos.x - transform.position.x) > 0.01f)
        {
            // x축을 중심으로 스프라이트 뒤집기
            transform.localScale = new Vector3(-Mathf.Sign(targetPos.x - transform.position.x), 1f, 1f);
        }
    }
    private void AttackButton()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            canMove = false;
            animator.SetTrigger("Attack");
            //StartCoroutine(EnableMovementAfterDelay(playerStatus.AttackSpeed));
            
        }
    }
    //private IEnumerator EnableMovementAfterDelay(float delay)
    //{
    //    Debug.Log(delay + "공격 딜레이 코루틴");
    //    yield return new WaitForSeconds(delay);
    //    EnableMovement();
    //}
    public void EnableMovement()
    {
        canMove = true;
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
                Debug.Log("상호작용");
            }
        }
    }
}