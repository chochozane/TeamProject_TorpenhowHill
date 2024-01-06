using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // GameManager ���� �����غ���

    // [SerializeField] private �ٸ� �Ŵ�����;
    [SerializeField] private PlayerStatus playerStats;
    // Canvas
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject settingCanvas;
    // Sliders
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider xpSlider;

    private float maxHp;

    //public bool isPaused { get; private set; } // �б�����, 
    public static bool isGamePaused { get; private set; } // �ٸ� ��ũ��Ʈ���� ���� ������ �����ϵ��� �޸𸮿� �Ҵ� - static, �б�����

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

    private void Start()
    {
        maxHp = playerStats.MaxHp;
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
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
        //UpdateHPUI();
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
        Debug.Log("���̺��ư ���� !");
    }
    public void OnPressedQuitBtn()
    {
        Debug.Log("�����ư ���� !");
        Application.Quit();
    }

    // todo Player info UI �����۾�
    public void UpdateHPUI(float currentHP)
    {
        hpSlider.value = GetHPPercentage(currentHP);
    }

    public float GetHPPercentage(float currentHP)
    {
        //Debug.Log("HPPERCENTAGE" + (float)Hp / MaxHp);
        return (currentHP / maxHp) * 1000f;
    }

    //public void UpdateHP(int value)
    //{
    //    hpSlider.value = + value
    //}
    //public void UpdateXP(int value)
    //{
    //xpSlider.value = +value
    // max value �� �Ǹ� level �� �����Բ�

    //}

}
