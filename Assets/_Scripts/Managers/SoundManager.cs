using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource; // 음악 플레이할 친구
    [SerializeField] private AudioClip bgm; // 음악 파일 그 자체

    [Header("# Inventory Sound")]
    [SerializeField] private AudioClip clickAudio; // 음악 파일 그 자체
    [SerializeField] private AudioClip toggleAudio; // 음악 파일 그 자체


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

        audioSource = GetComponent<AudioSource>();
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        audioSource.clip = bgm;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    
}
