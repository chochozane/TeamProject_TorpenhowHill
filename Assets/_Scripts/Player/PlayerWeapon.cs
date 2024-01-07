using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public PlayerStatus player;
    public float WeaponDamage { get; private set; }
    public void SetDamage() => WeaponDamage = player.Damage;

    
    public void dd()
    {
        Debug.Log(WeaponDamage + "무기데미지");
        Debug.Log(player.Damage + "플레이어뎀지");
        
    }

}
