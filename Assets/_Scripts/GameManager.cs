using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //�̱���

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyAngryPig;
    [SerializeField] private GameObject enemyBee;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PlayerInstance();
        EnemyAngryPigInstance();
        EnemyBeeInstance();
    }
    #region �ν��Ͻ�

    private void PlayerInstance()
    {
        Instantiate(player);
    }
    private void EnemyAngryPigInstance()
    {
        Instantiate(enemyAngryPig);
    }
    private void EnemyBeeInstance()
    {
        Instantiate(enemyBee);
    }



    #endregion








}
