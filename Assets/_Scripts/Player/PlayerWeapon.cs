using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false; // 공격 중인지를 추적하는 플래그

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        WeaponAttack(); // 무기 공격 로직 실행
    }

    private void WeaponAttack()
    {
        // "Attack" 애니메이션이 실행 중인지 확인하고 isAttacking 플래그가 false인 경우
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !isAttacking)
        {
            isAttacking = true; // 중복된 공격 적용을 방지하기 위해 플래그 설정
            ApplyDamage(10); // 10의 데미지 적용
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && isAttacking)
        {
            isAttacking = false; // 애니메이션이 끝나면 플래그 초기화
        }
    }

    private void ApplyDamage(int damage)
    {
        // 여기에 데미지 적용 로직 구현
        Debug.Log($"{damage} 데미지 적용");
    }
}
