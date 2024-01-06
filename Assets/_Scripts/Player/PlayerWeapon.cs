using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float weaponDamage;
    public PlayerStatus player;
    public float WeaponDamage { get; set; }
    public void SetDamage() => WeaponDamage = player.Damage;
}
