using UnityEngine;

public class ClockUI : MonoBehaviour
{
    private const float RealSecondsPerIngameDay = 60f; // ���� �ӿ��� 60�ʰ� �Ϸ� ��� ����.
    
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

        clockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay); // �ð�������� �Ϸ��� z�� ȸ���� - �� ���ƾ��Ѵ�.
    }
}
