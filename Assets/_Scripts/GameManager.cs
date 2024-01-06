using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //ΩÃ±€≈Ê

    [SerializeField] private GameObject enemyAngryPig;

    [Header("#Manager")]
    public UIManager uiManager;
    public SoundManager soundManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        uiManager = GetComponentInChildren<UIManager>();
        soundManager = GetComponentInChildren<SoundManager>();
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
