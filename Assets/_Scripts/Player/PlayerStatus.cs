using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public static PlayerStatus Instance;
    // 캐릭터의 경험치와 레벨
    public int Level { get; private set; } = 1;
    private int maxExperience = 1000; // 레벨업에 필요한 경험치
    private float statsMultiplier = 1.8f; // 레벨업 시 스탯 증가 비율
    private float HitCooldown = 1f; //플레이어 맞을 시 무적 시간

    // 총 능력치 (기본 + 추가)
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public float Damage { get; private set; }
    public float AttackSpeed { get; private set; }
    public int Xp { get; private set; }

    // 캐릭터의 기본 능력치
    public int BaseMaxHp { get; private set; }
    public int BaseHp { get; private set; }
    public int BaseDamage { get; private set; }
    public int BaseAttackSpeed { get; private set; }

    // 캐릭터의 추가 능력치
    public int AddMaxHp { get; private set; }
    public int AddHp { get; private set; }
    public int AddDamage { get; private set; }

    public CapsuleCollider2D Collider;
    private void Awake()
    {
        Collider = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        // 기본 능력치 초기화
        InitializeBaseStats();
        // 총 능력치 업데이트
        UpdateTotalStats();
    }

    private void InitializeBaseStats()
    {
        BaseMaxHp = 1000; // 예시 값
        BaseHp = 1000; // 예시 값
        BaseDamage = 100; // 예시 값
        BaseAttackSpeed = 1; // 예시 값
    }
    private void UpdateTotalStats()
    {
        MaxHp = BaseMaxHp + AddMaxHp;
        Hp = BaseHp + AddHp; 
        Damage = BaseDamage + AddDamage;
        AttackSpeed = BaseAttackSpeed;
    }

    // HP 수정 메소드 예시


    public void ModifyHp(int amount)
    {
        Hp += amount;
        Hp = Mathf.Clamp(Hp, 0, MaxHp); // HP가 범위 내에 있도록 보장
    }

    public void HitDamage (int damage)
    {
        Hp -= damage;
        Hp = Mathf.Clamp(Hp, 0, MaxHp); // HP가 범위 내에 있도록 보장
        Debug.Log(Hp);
    }
    // 경험치 추가 및 레벨업 처리
    public void GainExperience(int xp)
    {
        Xp += xp;
        while (Xp >= maxExperience && Level < 4)
        {
            LevelUp();
        }
    }
    // 레벨업 처리
    void LevelUp()
    {
        Level++;
        Xp -= maxExperience;

        // 레벨업에 따른 기본 스탯 증가
        AddMaxHp = Mathf.RoundToInt(BaseMaxHp * statsMultiplier);
        AddHp += AddHp;
        AddDamage = Mathf.RoundToInt(BaseDamage * statsMultiplier);
        UpdateTotalStats(); // 총 능력치 업데이트
    }
    IEnumerator NoneHit()
    {
        Collider.enabled = false; //콜라이더 끄기
        yield return new WaitForSeconds(HitCooldown); // HitCooldown 만큼 무적시간이 됨
        Collider.enabled = true; //콜라이더 켜기
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //collision.gameObject.GetComponent<Monster>().level == 1
        {
            Debug.Log("플레이어가 공격 받았다.");
            HitDamage(collision.gameObject.GetComponent<MeleeEnemy1>().Attack());
            //StartCoroutine(NoneHit());
        }        
    }
}
