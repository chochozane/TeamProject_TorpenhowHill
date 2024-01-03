using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 총 능력치 (기본 + 추가)
    public int maxHp { get; private set; }
    public int hp { get; private set; }
    public float damage { get; private set; }
    public float defense { get; private set; }
    public float attackSpeed { get; private set; }

    // 캐릭터의 기본 능력치
    public int BaseMaxHp { get; private set; }
    public int BaseHp { get; private set; }
    public int BaseDamage { get; private set; }
    public int BaseDefense { get; private set; }
    public int BaseAttackSpeed { get; private set; }

    void Start()
    {
        // 기본 능력치 초기화
        InitializeBaseStats();
        // 총 능력치 업데이트
        UpdateTotalAbilities();
    }

    void InitializeBaseStats()
    {
        BaseMaxHp = 100; // 예시 값
        BaseHp = 100; // 예시 값
        BaseDamage = 10; // 예시 값
        BaseDefense = 5; // 예시 값
        BaseAttackSpeed = 1; // 예시 값
    }

    void UpdateTotalAbilities()
    {
        maxHp = BaseMaxHp; // 추가 수정자가 있으면 추가
        hp = BaseHp; // 추가 수정자가 있으면 추가
        damage = BaseDamage; // 추가 수정자가 있으면 추가
        defense = BaseDefense; // 추가 수정자가 있으면 추가
        attackSpeed = BaseAttackSpeed; // 추가 수정자가 있으면 추가
    }

    // HP 수정 메소드 예시
    public void ModifyHp(int amount)
    {
        hp += amount;
        hp = Mathf.Clamp(hp, 0, maxHp); // HP가 범위 내에 있도록 보장
    }

    // 데미지, 방어력 등을 수정하는 메소드 추가
}
