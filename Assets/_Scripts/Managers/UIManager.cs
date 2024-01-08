using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // GameManager 역할 연습해보자

    // [SerializeField] private 다른 매니저들;
    [SerializeField] private PlayerStatus playerStats;
    // Canvas
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject settingCanvas;
    // Sliders
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider xpSlider;
    // Text
    [SerializeField] private TMP_Text levelText;

    private float maxHp;
    private float maxXp;


    //public bool isPaused { get; private set; } // 읽기전용, 
    public static bool isGamePaused { get; private set; } // 다른 스크립트에서 쉽게 접근이 가능하도록 메모리에 할당 - static, 읽기전용

    // 싱글톤
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //maxHp = playerStats.MaxHp;
        //hpSlider.maxValue = maxHp;
        //hpSlider.value = maxHp;
        //Debug.Log("UIManager에서 maxHP " + maxHp);

        //Debug.Log("maxXP:" + maxXp);
        //maxXp = playerStats.MaxXp;
        //xpSlider.maxValue = maxXp;
        //xpSlider.value = 0;
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
        SoundManager.instance.uiSound.ToggleAudio();
        PauseTime();
        inGameCanvas.SetActive(false);
        settingCanvas.SetActive(true);
    }
    
    public void OnPressedCloseBtn()
    {
        SoundManager.instance.uiSound.ClickAudio();
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

    //public void OnPressedSaveBtn()
    //{
    //    Debug.Log("세이브버튼 누름 !");
    //}

    public void OnPressedQuitBtn()
    {
        Debug.Log("종료버튼 누름 !");
        Application.Quit();
    }

    // todo Player info UI 연결작업
    public void UpdateMaxHPUI(float currentMaxHP)
    {
        hpSlider.maxValue = currentMaxHP;
        hpSlider.value = hpSlider.maxValue;
    }
    public void UpdateHPUI(float currentHP)
    {
        hpSlider.value = currentHP;
    }

    public void UpdateMaxXPUI(float currentMaxXP)
    {
        xpSlider.maxValue = currentMaxXP;
    }

    public void UpdateXPUI(float currentXP)
    {
        xpSlider.value = currentXP;
    }


    public void UpdateLevelText(int level)
    {
        levelText.text = "Lv. " + GetLevelText(level).ToString();
    }

    private int GetLevelText(int level)
    {
        return level;
    }

}
