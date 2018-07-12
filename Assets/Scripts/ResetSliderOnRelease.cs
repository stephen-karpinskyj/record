using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ResetSliderOnRelease : MonoBehaviour, IEndDragHandler, IPointerUpHandler
{
    Slider slider;

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    
    public void OnEndDrag(PointerEventData data)
    {
        ResetSlider();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetSlider();
    }

    void ResetSlider()
    {
        slider.value = 0f;
    }
}
