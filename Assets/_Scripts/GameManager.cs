using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //�̱���

    [Header("#Manager")]
    public UIManager uiManager;
    public SoundManager soundManager;

    [Header("#Game")]
    [SerializeField] private GameObject GmaeOverImage;
    [SerializeField] private GameObject VictoryImage;

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
    
    public void GameOver()
    {
        GmaeOverImage.SetActive(true);
        UIManager.instance.PauseTime();
    }

    public void Victory()
    {
        VictoryImage.SetActive(true);
        UIManager.instance.PauseTime();
    }

    public void StartSceneButton()
    {
        SceneManager.LoadScene("StartScene");
        UIManager.instance.ResumeTime();
    }

    public void ContinueButton()
    {
        VictoryImage.SetActive(false);
        UIManager.instance.ResumeTime();
    }





}
