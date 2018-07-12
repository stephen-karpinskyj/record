using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;

public class ShipControlsUI : MonoBehaviour
{
    [SerializeField]
    RectTransform controlsParent;

    [SerializeField]
    float showDuration = 0.1f;

    [SerializeField]
    Text mainThrusterDirectionText;
    
    [SerializeField]
    Slider mainThrusterSlider;

    [SerializeField]
    Slider cwThrusterSlider;

    [SerializeField]
    Slider ccwThrusterSlider;
    
    [SerializeField]
    Thruster mainThruster;
    
    [SerializeField]
    Thruster reverseThruster;

    [SerializeField]
    Thruster cwThruster;

    [SerializeField]
    Thruster ccwThruster;
    
    [SerializeField]
    AnimationCurve thrusterCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    
    bool forward;
    
    bool showing;
    Vector2 showingPosition;
    Vector2 hidingPosition;
    
    void Awake()
    {
        forward = true;
        SetMainThrusterDirection(forward);
        
        showingPosition = controlsParent.anchoredPosition;
        hidingPosition = -controlsParent.sizeDelta;
        
        showing = false;
        SetPosition(hidingPosition);
    }

    void SetMainThrusterDirection(bool fwd)
    {
        forward = fwd;
        mainThrusterDirectionText.text = forward ? "FWD" : "REV";
    }
    
    void SetPosition(Vector2 position)
    {
        controlsParent.anchoredPosition = position;
    }
    
    void HandleTweenComplete()
    {
        SetPosition(showing ? showingPosition : hidingPosition);
    }
    
    public void UGUI_HandleToggleControlsButtonClick()
    {
        showing = !showing;
        var from = showing ? hidingPosition : showingPosition;
        var to = showing ? showingPosition : hidingPosition;
        Tween.Value(from, to, SetPosition, showDuration, 0f, Tween.EaseInOut, completeCallback: HandleTweenComplete);
    }
    
    public void UGUI_HandleToggleMainThrusterButtonClick()
    {
        SetMainThrusterDirection(!forward);
    }

    public void UGUI_HandleMainThrusterSliderValueChange()
    {
        var thruster = forward ? mainThruster : reverseThruster;
        var otherThruster = forward ? reverseThruster : mainThruster;
        thruster.SetThrottle(thrusterCurve.Evaluate(mainThrusterSlider.value));
        otherThruster.SetThrottle(0f);
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
