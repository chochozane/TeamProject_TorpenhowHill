using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource; // ���� �÷����� ģ��
    [SerializeField] private AudioClip bgm; // ���� ���� �� ��ü

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        audioSource.clip = bgm;
        audioSource.Play();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
