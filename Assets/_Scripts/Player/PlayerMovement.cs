using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // 플레이어 이동 속도
    [SerializeField] private float attackRange = 2f; // 공격 범위
    [SerializeField] private float attackSpeed = 1f; // 초당 공격 횟수

    Vector3 mousePos, transPos, targetPos;
    private GameObject targetEnemy = null;
    private float lastAttackTime;
    private bool NPCTalkOn = false;

    private void Start()
    {
        AttackButton(); // 공격 버튼 로직 실행
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalTargetPos(); // 타겟 위치 계산
        }
        MoveToTarget(); // 타겟 위치로 이동
        FlipSprite(); // 스프라이트 뒤집기
        EffectButton(); // 'F' 버튼으로 상호작용 (예: NPC 대화)
        
    }

    private void CalTargetPos()
    {
        mousePos = Input.mousePosition; // 마우스 위치 가져오기
        transPos = Camera.main.ScreenToWorldPoint(mousePos); // 마우스 위치를 월드 포인트로 변환
        targetPos = new Vector3(transPos.x, transPos.y, 0); // z 좌표는 0으로 설정
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed); // 타겟 위치로 이동
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

    private void EffectButton()
    {
        if (Input.GetKey(KeyCode.F)) // F 키가 눌렸는지 확인
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f); // 현재 위치에서 반경 1f 내의 모든 콜라이더 감지
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("NPC")) // 콜라이더의 태그가 'NPC'인지 확인
                {
                    NPCTalkOn = true; // NPC와 접촉했으므로 NPCTalkOn을 true로 설정
                    break; // NPC를 찾았으니 더 이상 다른 콜라이더를 확인할 필요 없음
                }
            }
        }
    }

    private void AttackButton()
    {
        if (Input.GetMouseButton(0)) // 왼쪽 마우스 버튼 클릭 확인
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("enemy"))
            {
                targetEnemy = hit.collider.gameObject; // 클릭된 적을 타겟으로 설정
            }
        }

        if (targetEnemy != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.transform.position);

            if (distanceToEnemy <= attackRange)
            {
                if (Time.time - lastAttackTime >= 1f / attackSpeed)
                {
                    Attack(); // 공격 실행
                    lastAttackTime = Time.time; // 마지막 공격 시간 업데이트
                }
            }
            else
            {
                MoveToTarget(targetEnemy.transform.position); // 적에게 이동
            }
        }
    }

    private void Attack()
    {
        // 여기에 공격 로직 구현 (예: 적 체력 감소)
    }

    private void MoveToTarget(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed); // 타겟 위치로 이동
    }
}