using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //ΩÃ±€≈Ê

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
        EnemyAngryPigInstance();
    }
    #region ¿ŒΩ∫≈œΩ∫

    private void EnemyAngryPigInstance()
    {
        Instantiate(enemyAngryPig);
    }
    #endregion








}
