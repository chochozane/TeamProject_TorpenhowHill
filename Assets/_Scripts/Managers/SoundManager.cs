using System.Collections;
using System.Collections.Generic;
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
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        audioSource.clip = bgm;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
