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
