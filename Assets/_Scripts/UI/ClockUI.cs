using UnityEngine;
using UnityEngine.EventSystems;
public class ClockUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject dayText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스가 UI 요소 위에 진입했을 때 호출되는 함수
        dayText.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스가 UI 요소에서 나갔을 때 호출되는 함수
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
