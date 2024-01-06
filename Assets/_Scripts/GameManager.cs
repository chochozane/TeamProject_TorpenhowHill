using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// GameManager.Instance.uiManager.�޼���
    /// GameManager.Instance.soundManager.�޼���
    /// </summary>
    public static GameManager Instance; //�̱���

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
    #region �ν��Ͻ�

    private void EnemyAngryPigInstance()
    {
        Instantiate(enemyAngryPig);
    }
    #endregion





}
