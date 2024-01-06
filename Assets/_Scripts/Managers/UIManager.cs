using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // GameManager 역할 연습해보자

    // [SerializeField] private 다른 매니저들;

    // Canvas
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject settingCanvas;
    // Sliders
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider xpSlider;

    //public bool isPaused { get; private set; } // 읽기전용, 
    public static bool isGamePaused { get; private set; } // 다른 스크립트에서 쉽게 접근이 가능하도록 메모리에 할당 - static, 읽기전용

    // 싱글톤
    //public static UIManager instance;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(instance);
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void PauseTime()
    {
        isGamePaused = true;
        //Time.timeScale = 0.0f;
    }

    public void ResumeTime()
    {
        isGamePaused = false;
        //Time.timeScale = 1.0f;
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
        Debug.Log("종료버튼 누름 !");
        Application.Quit();
    }

    // todo Player info UI 연결작업
    //public void UpdateHP(int value)
    //{
    //    hpSlider.value = + value
    //}
    //public void UpdateXP(int value)
    //{
        //xpSlider.value = +value
        // max value 가 되면 level 이 오르게끔

    //}

}
