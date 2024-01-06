using UnityEngine;
using UnityEngine.EventSystems;
public class ClockUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject dayText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���콺�� UI ��� ���� �������� �� ȣ��Ǵ� �Լ�
        dayText.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
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
        // ���콺�� UI ��ҿ��� ������ �� ȣ��Ǵ� �Լ�
        dayText.SetActive(false);
    }
}

//public class ClockUI : MonoBehaviour
//{
//    [SerializeField] private GameObject dayText;



//    private void OnMouseEnter()
//    {
//        dayText.SetActive(true);
//    }

//    private void OnMouseExit()
//    {
//        dayText.SetActive(false);

//    }
//}
