using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public static PlayerStatus Instance;

    // ĳ������ ����ġ�� ����
    public int Level { get; private set; } = 1;
    private float statsMultiplier = 8f; // ������ �� ���� ���� ����
    private float HitCooldown = 1f; //�÷��̾� ���� �� ���� �ð�

    // �� �ɷ�ġ (�⺻ + �߰�)
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public float Damage { get; private set; }
    public float AttackSpeed { get; private set; }
    public int MaxXp { get; private set; }
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
        MaxXp = 1000;
        Xp = 0;
        BaseMaxHp = 1000; // ���� ��
        BaseHp = 1000; // ���� ��
        BaseDamage = 100; // ���� ��
        BaseAttackSpeed = 1; // ���� ��

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
        Debug.Log(Hp + ": ���� �÷��̾� ü��");
        
        UIManager.instance.UpdateHPUI(Hp);
    }


    // ����ġ �߰� �� ������ ó��
    public void GainExperience(int xp)
    {
        Xp += xp;
        Debug.Log("xp���� :" + Xp);
        while (Xp >= MaxXp && Level < 4)
        {
            LevelUp();
        }
        
        UIManager.instance.UpdateXPUI(Xp);
    }
    // ������ ó��
    void LevelUp()
    {
        Level++;
        Xp -= MaxXp;
        // �������� ���� �⺻ ���� ����
        MaxXp *= 50;
        Debug.Log(MaxXp + "�ִ� ����ġ");
        AddMaxHp = Mathf.RoundToInt(MaxHp * statsMultiplier);
        MaxHp = AddMaxHp;
        Hp = MaxHp;
        AddDamage = 100;
        Damage += AddDamage;
        UIManager.instance.UpdateMaxXPUI(MaxXp);
        UIManager.instance.UpdateLevelText(Level);
        UIManager.instance.UpdateMaxHPUI(MaxHp);
        Debug.Log(MaxHp);

        Debug.Log("���� Level" + Level);
        Debug.Log("���� Hp" + Hp);
        Debug.Log("���� Damage" + Damage);
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
