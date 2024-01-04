using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // GameManager 역할 연습해보자

    // [SerializeField] private 다른 매니저들;

    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject settingCanvas;

    //public bool isPaused { get; private set; } // 읽기전용, 
    public static bool isGamePaused { get; private set; } // 다른 스크립트에서 쉽게 접근이 가능하도록

    // 싱글톤
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PauseTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }

    public void OnPressedSettingBtn()
    {
        PauseTime();
        inGameCanvas.SetActive(false);
        settingCanvas.SetActive(true);
    }
    
    public void OnPressedCloseBtn()
    {
        ResumeTime();
        inGameCanvas.SetActive(true);
        settingCanvas.SetActive(false);
    }

    public void OnPressedResumeBtn()
    {
        ResumeTime();
        inGameCanvas.SetActive(true);
        settingCanvas.SetActive(false);

    }

    public void OnPressedSaveBtn()
    {
        Debug.Log("세이브버튼 누름 !");
    }
    public void OnPressedQuitBtn()
    {
        Application.Quit();
    }
}
