using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public static UISound Instance;

    private AudioSource audioSource;
    [Header("# Inventory Sound")]
    [SerializeField] private AudioClip clickAudio; // ���� ���� �� ��ü
    [SerializeField] private AudioClip toggleAudio; // ���� ���� �� ��ü

    private void Awake()
    {
        Instance = this;
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
