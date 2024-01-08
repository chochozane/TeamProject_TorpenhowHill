using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //ΩÃ±€≈Ê

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
    








}
