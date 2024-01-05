using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //�̱���

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyAngryPig;

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
    #endregion








}
