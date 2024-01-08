using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public static PlayerStatus Instance;

    // 캐릭터의 경험치와 레벨
    public int Level { get; private set; } = 1;
    private float statsMultiplier = 8f; // 레벨업 시 스탯 증가 비율
    private float HitCooldown = 1f; //플레이어 맞을 시 무적 시간

    // 총 능력치 (기본 + 추가)
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public float Damage { get; private set; }
    public float AttackSpeed { get; private set; }
    public int MaxXp { get; private set; }
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
        MaxXp = 1000;
        Xp = 0;
        BaseMaxHp = 1000; // 예시 값
        BaseHp = 1000; // 예시 값
        BaseDamage = 100; // 예시 값
        BaseAttackSpeed = 1; // 예시 값

        //UIManager.instance.UpdateHPUI(BaseHp);
        UIManager.instance.UpdateMaxHPUI(BaseMaxHp);
        Debug.Log("BaseHp : " + BaseHp);
        Debug.Log("BaseMaxHp : " + BaseMaxHp);

        UIManager.instance.UpdateXPUI(Xp);
        UIManager.instance.UpdateMaxXPUI(MaxXp);

    }
    private void UpdateTotalStats()
    {
        MaxHp = BaseMaxHp;
        Hp = BaseHp; 
        Damage = BaseDamage;
        AttackSpeed = BaseAttackSpeed;
    }

    // HP 수정 메소드 예시


    public void ModifyHp(int amount)
    {
        Hp += amount;
        Hp = Mathf.Clamp(Hp, 0, MaxHp); // HP가 범위 내에 있도록 보장
        UIManager.instance.UpdateHPUI(Hp);

    }

    public void HitDamage (int damage)
    {
        Hp -= damage;
        Hp = Mathf.Clamp(Hp, 0, MaxHp); // HP가 범위 내에 있도록 보장
        Debug.Log(Hp + ": 현재 플레이어 체력");
        
        UIManager.instance.UpdateHPUI(Hp);
    }


    // 경험치 추가 및 레벨업 처리
    public void GainExperience(int xp)
    {
        Xp += xp;
        Debug.Log("xp얻음 :" + Xp);
        while (Xp >= MaxXp && Level < 4)
        {
            LevelUp();
        }
        
        UIManager.instance.UpdateXPUI(Xp);
    }
    // 레벨업 처리
    void LevelUp()
    {
        Level++;
        Xp -= MaxXp;
        // 레벨업에 따른 기본 스탯 증가
        MaxXp *= 50;
        Debug.Log(MaxXp + "최대 경험치");
        AddMaxHp = Mathf.RoundToInt(MaxHp * statsMultiplier);
        MaxHp = AddMaxHp;
        Hp = MaxHp;
        AddDamage = 100;
        Damage += AddDamage;
        UIManager.instance.UpdateMaxXPUI(MaxXp);
        UIManager.instance.UpdateLevelText(Level);
        UIManager.instance.UpdateMaxHPUI(MaxHp);
        Debug.Log(MaxHp);

        Debug.Log("현재 Level" + Level);
        Debug.Log("현재 Hp" + Hp);
        Debug.Log("현재 Damage" + Damage);
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
            if(collision.gameObject.GetComponent<MeleeEnemy1>()) 
            {
                HitDamage(collision.gameObject.GetComponent<MeleeEnemy1>().Attack());
            }
            if (collision.gameObject.GetComponent<MeleeEnemy2>())
            {
                HitDamage(collision.gameObject.GetComponent<MeleeEnemy2>().Attack());
            }
            if (collision.gameObject.GetComponent<MeleeEnemy3>())
            {
                HitDamage(collision.gameObject.GetComponent<MeleeEnemy3>().Attack());
            }

            //StartCoroutine(NoneHit());
        }        
    }
}
