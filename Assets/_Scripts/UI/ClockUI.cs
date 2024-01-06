using UnityEngine;

public class ClockUI : MonoBehaviour
{
    private const float RealSecondsPerIngameDay = 60f; // 게임 속에서 60초가 하루 라고 가정.
    
    private Transform clockHandTransform;

    private float day;

    private void Awake()
    {
        clockHandTransform = transform.Find("ClockHand");
    }

    private void Update()
    {
        //if (UIManager.instance.isPaused)
        //{
        //    UIManager.instance.PauseTime();
        //}
        if (UIManager.isGamePaused)
        {
            //UIManager.instance.PauseTime();
            GameManager.Instance.uiManager.PauseTime();
        }


        day += Time.deltaTime / RealSecondsPerIngameDay;

        float dayNormalized = day % 1f;
        float rotationDegreesPerDay = 360f;

        clockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay); // 시계방향으로 하려면 z축 회전이 - 로 돌아야한다.
    }
}
