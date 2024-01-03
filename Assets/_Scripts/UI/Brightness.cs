using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{

    [SerializeField] private Slider brightnessSlider;

    [SerializeField] private PostProcessProfile brightnessProfile;
    [SerializeField] private PostProcessLayer layer;

    private AutoExposure exposure;

    // Start is called before the first frame update
    private void Start()
    {
        brightnessProfile.TryGetSettings(out exposure);
        AdjustBrightness(brightnessSlider.value); // 게임 플레이 전에 설정되어 있는 slider 의 value 값에 맞춰서 밝기가 조절되어 플레이 될 것이다.
    }

    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }
}
