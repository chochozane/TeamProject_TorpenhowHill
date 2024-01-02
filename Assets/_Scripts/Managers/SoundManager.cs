using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // ���� �÷����� ģ��
    [SerializeField] private AudioClip bgm; // ���� ���� �� ��ü

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
