using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// GameManager.Instance.uiManager.메서드
    /// GameManager.Instance.soundManager.메서드
    /// </summary>
    public static GameManager Instance; //싱글톤

    [Header("#Manager")]
    public UIManager uiManager;
    public SoundManager soundManager;

    [Space(10f)]
    [SerializeField] private GameObject enemyAngryPig;


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
        uiManager = GetComponentInChildren<UIManager>();
        soundManager = GetComponentInChildren<SoundManager>();
    }
    private void Start()
    {
        EnemyAngryPigInstance();
    }
    #region 인스턴스

    private void EnemyAngryPigInstance()
    {
        Instantiate(enemyAngryPig);
    }
    #endregion





}
