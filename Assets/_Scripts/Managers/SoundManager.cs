using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource; // 음악 플레이할 친구
    [SerializeField] private AudioClip bgm; // 음악 파일 그 자체

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
