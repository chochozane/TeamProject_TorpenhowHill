using UnityEngine;

public class UIManager : MonoBehaviour
{
    // GameManager ���� �����غ���

    // [SerializeField] private �ٸ� �Ŵ�����;

    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject settingCanvas;

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

    public void PauseTime()
    {
        isGamePaused = true;
        Time.timeScale = 0.0f;
    }

    public void ResumeTime()
    {
        isGamePaused = false;
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

    // todo Player info UI �����۾�
}
