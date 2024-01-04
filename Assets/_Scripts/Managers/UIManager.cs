using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // GameManager ���� �����غ���

    // [SerializeField] private �ٸ� �Ŵ�����;

    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject settingCanvas;

    //public bool isPaused { get; private set; } // �б�����, 
    public static bool isGamePaused { get; private set; } // �ٸ� ��ũ��Ʈ���� ���� ������ �����ϵ���

    // �̱���
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
        Debug.Log("���̺��ư ���� !");
    }
    public void OnPressedQuitBtn()
    {
        Application.Quit();
    }
}
