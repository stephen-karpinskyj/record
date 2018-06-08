using UnityEngine;
using UnityEngine.UI;

public class ReleasableSlider : Slider
{
    [SerializeField]
    SliderEvent onReleased;

    public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        onReleased.Invoke(value);
    }
}
