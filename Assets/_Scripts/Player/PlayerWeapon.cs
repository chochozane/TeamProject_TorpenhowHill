using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private PlayerStatus playerStatus;
    public float weaponDamage;

    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();

        if (playerStatus != null)
        {
            weaponDamage = playerStatus.Damage;
        }
    }
}
