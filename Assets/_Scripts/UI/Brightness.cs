using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class Brightness : MonoBehaviour
{

    [SerializeField] private Slider brightnessSlider;

    [SerializeField] private PostProcessProfile brightnessProfile;
    [SerializeField] private PostProcessLayer layer;
    [SerializeField] private TMP_Text brightnessPercentageText;

    private AutoExposure exposure;

    // Start is called before the first frame update
    private void Start()
    {
        brightnessProfile.TryGetSettings(out exposure);
        AdjustBrightness(brightnessSlider.value); // ���� �÷��� ���� �����Ǿ� �ִ� slider �� value ���� ���缭 ���� �÷��� �� ��Ⱑ �����Ǿ� ���� ���̴�.
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
        brightnessPercentageText.text = ((value * 100).ToString("F0") + "%");
    }
}
