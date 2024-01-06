using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public static SoundManager instance;

    private AudioSource audioSource; // ���� �÷����� ģ��
    [SerializeField] private AudioClip bgm; // ���� ���� �� ��ü

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
