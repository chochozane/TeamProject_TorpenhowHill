using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public static PlayerStatus Instance;
    // ĳ������ ����ġ�� ����
    public int Level { get; private set; } = 1;
    public int maxExperience {get; private set;} = 1000;// �������� �ʿ��� ����ġ
    private float statsMultiplier = 1.8f; // ������ �� ���� ���� ����
    private float HitCooldown = 1f; //�÷��̾� ���� �� ���� �ð�

    // �� �ɷ�ġ (�⺻ + �߰�)
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public float Damage { get; private set; }
    public float AttackSpeed { get; private set; }
    public int Xp { get; private set; }

    // ĳ������ �⺻ �ɷ�ġ
    public int BaseMaxHp { get; private set; }
    public int BaseHp { get; private set; }
    public int BaseDamage { get; private set; }
    public int BaseAttackSpeed { get; private set; }

    // ĳ������ �߰� �ɷ�ġ
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
        // �⺻ �ɷ�ġ �ʱ�ȭ
        InitializeBaseStats();
        // �� �ɷ�ġ ������Ʈ
        UpdateTotalStats();
    }

    private void InitializeBaseStats()
    {
        BaseMaxHp = 1000; // ���� ��
        BaseHp = 1000; // ���� ��
        BaseDamage = 100; // ���� ��
        BaseAttackSpeed = 1; // ���� ��
    }
    private void UpdateTotalStats()
    {
        MaxHp = BaseMaxHp + AddMaxHp;
        Hp = BaseHp + AddHp; 
        Damage = BaseDamage + AddDamage;
        AttackSpeed = BaseAttackSpeed;
    }

    // HP ���� �޼ҵ� ����


    public void ModifyHp(int amount)
    {
        Hp += amount;
        Hp = Mathf.Clamp(Hp, 0, MaxHp); // HP�� ���� ���� �ֵ��� ����
        UIManager.instance.UpdateHPUI(Hp);

    }

    public void HitDamage (int damage)
    {
        Hp -= damage;
        Hp = Mathf.Clamp(Hp, 0, MaxHp); // HP�� ���� ���� �ֵ��� ����
        Debug.Log(Hp);
        UIManager.instance.UpdateHPUI(Hp);

    }


    // ����ġ �߰� �� ������ ó��
    public void GainExperience(int xp)
    {
        Xp += xp;
        Debug.Log("xp���� :" + Xp);
        UIManager.instance.UpdateXPUI(Xp);
        while (Xp >= maxExperience && Level < 4)
        {
            LevelUp();
        }
    }
    // ������ ó��
    void LevelUp()
    {
        Level++;
        Xp -= maxExperience;
        Debug.Log("���� Level" + Level);

        // �������� ���� �⺻ ���� ����
        AddMaxHp = Mathf.RoundToInt(BaseMaxHp * statsMultiplier);
        AddHp += AddHp;
        AddDamage = Mathf.RoundToInt(BaseDamage * statsMultiplier);
        UpdateTotalStats(); // �� �ɷ�ġ ������Ʈ
        UIManager.instance.UpdateXPUI(Xp);
        UIManager.instance.UpdateLevelText(Level);
        UIManager.instance.UpdateHPUI(Hp);
    }
    IEnumerator NoneHit()
    {
        Collider.enabled = false; //�ݶ��̴� ����
        yield return new WaitForSeconds(HitCooldown); // HitCooldown ��ŭ �����ð��� ��
        Collider.enabled = true; //�ݶ��̴� �ѱ�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //collision.gameObject.GetComponent<Monster>().level == 1
        {
            Debug.Log("�÷��̾ ���� �޾Ҵ�.");
            HitDamage(collision.gameObject.GetComponent<MeleeEnemy1>().Attack());
            //StartCoroutine(NoneHit());
        }        
    }
}
