using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    private Slider healthSlider;
    private PlayerStatus playerStatus;

    int maxHealth;
    int currentHealth;
    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        playerStatus = GetComponent<PlayerStatus>();
        maxHealth = playerStatus.MaxHp;
        currentHealth = playerStatus.Hp;
    }
    public void SetHealth()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
