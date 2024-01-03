using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // �� �ɷ�ġ (�⺻ + �߰�)
    public int maxHp { get; private set; }
    public int hp { get; private set; }
    public float damage { get; private set; }
    public float defense { get; private set; }
    public float attackSpeed { get; private set; }

    // ĳ������ �⺻ �ɷ�ġ
    public int BaseMaxHp { get; private set; }
    public int BaseHp { get; private set; }
    public int BaseDamage { get; private set; }
    public int BaseDefense { get; private set; }
    public int BaseAttackSpeed { get; private set; }

    void Start()
    {
        // �⺻ �ɷ�ġ �ʱ�ȭ
        InitializeBaseStats();
        // �� �ɷ�ġ ������Ʈ
        UpdateTotalAbilities();
    }

    void InitializeBaseStats()
    {
        BaseMaxHp = 100; // ���� ��
        BaseHp = 100; // ���� ��
        BaseDamage = 10; // ���� ��
        BaseDefense = 5; // ���� ��
        BaseAttackSpeed = 1; // ���� ��
    }

    void UpdateTotalAbilities()
    {
        maxHp = BaseMaxHp; // �߰� �����ڰ� ������ �߰�
        hp = BaseHp; // �߰� �����ڰ� ������ �߰�
        damage = BaseDamage; // �߰� �����ڰ� ������ �߰�
        defense = BaseDefense; // �߰� �����ڰ� ������ �߰�
        attackSpeed = BaseAttackSpeed; // �߰� �����ڰ� ������ �߰�
    }

    // HP ���� �޼ҵ� ����
    public void ModifyHp(int amount)
    {
        hp += amount;
        hp = Mathf.Clamp(hp, 0, maxHp); // HP�� ���� ���� �ֵ��� ����
    }

    // ������, ���� ���� �����ϴ� �޼ҵ� �߰�
}
