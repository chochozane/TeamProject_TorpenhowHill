using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    private AudioSource audioSource;
    [Header("# Inventory Sound")]
    [SerializeField] private AudioClip clickAudio; // 음악 파일 그 자체
    [SerializeField] private AudioClip toggleAudio; // 음악 파일 그 자체

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ClickAudio()
    {

        audioSource.clip = clickAudio;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    public void ToggleAudio()
    {
        audioSource.clip = toggleAudio;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
