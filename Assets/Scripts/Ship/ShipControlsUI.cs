using UnityEngine;
using UnityEngine.UI;

public class ShipControlsUI : MonoBehaviour
{
    [SerializeField]
    GameObject controlsParent;
    
    [SerializeField]
    Slider mainThrusterSlider;

    [SerializeField]
    Slider cwThrusterSlider;

    [SerializeField]
    Slider ccwThrusterSlider;
    
    [SerializeField]
    Thruster mainThruster;

    [SerializeField]
    Thruster cwThruster;

    [SerializeField]
    Thruster ccwThruster;
    
    [SerializeField]
    AnimationCurve thrusterCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    
    void Awake()
    {
        controlsParent.SetActive(false);
    }

    public void UGUI_HandleToggleControlsButtonClick()
    {
        controlsParent.SetActive(!controlsParent.activeSelf);
    }

    public void UGUI_HandleMainThrusterSliderValueChange()
    {
        mainThruster.SetThrottle(thrusterCurve.Evaluate(mainThrusterSlider.value));
    }

    public void UGUI_HandleCWThrusterSliderValueChange()
    {
        cwThruster.SetThrottle(thrusterCurve.Evaluate(cwThrusterSlider.value));
    }
    
    public void UGUI_HandleCCWThrusterSliderValueChange()
    {
        ccwThruster.SetThrottle(thrusterCurve.Evaluate(ccwThrusterSlider.value));
    }
}
