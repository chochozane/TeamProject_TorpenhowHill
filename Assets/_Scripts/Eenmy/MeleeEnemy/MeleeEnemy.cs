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
            // 플레이어와 부딛히면 플레이어에게 대미지를 입히는 로직을 구현합니다.
            int damage = GetComponent<EnemyStats>().attackDamage;
            //collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
