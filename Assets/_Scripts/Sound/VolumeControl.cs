using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private Slider soundSlider;

    private void Awake()
    {
        soundSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        //soundSlider.value = 0.5f;
        soundSlider.value = 1f;
    }

    public void SetLevel(float sliderValue)
    {
        // instead of just directly setting the sliderValue, we need to convert it into logarithmic value !
        // Mathf.Log10() 을 통해 convert 진행하자
        audioMixer.SetFloat("BGMVol", Mathf.Log10(sliderValue) * 20 ); 
    }
}
