using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public PlayerStatus player;
    public float WeaponDamage { get; private set; }

    public void SetDamage()
    {
        WeaponDamage = player.Damage;
    }

}
