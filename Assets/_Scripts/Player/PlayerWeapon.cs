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
        Debug.Log(WeaponDamage + "���ⵥ����");
        Debug.Log(player.Damage + "�÷��̾��");
        
    }

}
