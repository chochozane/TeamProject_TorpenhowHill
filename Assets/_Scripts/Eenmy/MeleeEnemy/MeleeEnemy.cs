using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �÷��̾�� �ε����� �÷��̾�� ������� ������ ������ �����մϴ�.
            int damage = GetComponent<EnemyStats>().attackDamage;
            //collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
