using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private PlayerStatus playerStatus;
    public float weaponDamage;

    private void Start()
    {


        if (playerStatus != null)
        {
            weaponDamage = playerStatus.Damage; // 플레이어 공격력 = 무기 공격력
        }

    }
}
