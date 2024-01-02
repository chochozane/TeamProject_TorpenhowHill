using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // 음악 플레이할 친구
    [SerializeField] private AudioClip bgm; // 음악 파일 그 자체

    // Start is called before the first frame update
    private void Start()
    {
        audioSource.clip = bgm;
        audioSource.Play();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
