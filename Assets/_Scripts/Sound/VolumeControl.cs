using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMP_Text volumeText;

    private Slider soundSlider;


    private void Awake()
    {
        soundSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        soundSlider.value = 1f;
    }

    public void SetLevel(float sliderValue) // slider �ο�
    {
        // instead of just directly setting the sliderValue, we need to convert it into logarithmic value !
        // Mathf.Log10() �� ���� convert ��������
        audioMixer.SetFloat("BGMVol", Mathf.Log10(sliderValue) * 20 );
        volumeText.text = (sliderValue * 100).ToString("F0");
    }
}
