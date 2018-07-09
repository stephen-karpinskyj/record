using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DigitalRubyShared;

public class UI : MonoBehaviour
{
    [Header("Time")]
    
    [SerializeField]
    float[] timeScaleSteps = { 0.25f, 0.5f, 1f, 2f, 5f, 15f, 30f, 60f, 100f };

    [SerializeField]
    int defaultTimeScaleStepIndex = 2;
    
    [SerializeField]
    Text timeScaleText;
    
    [Header("Zoom")]

    [SerializeField, Range(0f, 1f)]
    float defaultCameraZoomPercentage = 0.1f;

    [SerializeField]
    AnimationCurve zoomCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [SerializeField]
    Vector2 cameraZoomRange = new Vector2(5f, 10000f);
    
    [SerializeField]
    float zoomScrollWheelSpeed = 1f;

    [SerializeField]
    float pinchZoomSpeed = 1f;
    
    [SerializeField]
    Slider cameraZoomSlider;

    int timeScaleStepIndex;
    float cameraZoomRangeDiff;
    ScaleGestureRecognizer scaleGesture;

    void Awake()
    {
        timeScaleStepIndex = defaultTimeScaleStepIndex;
        cameraZoomRangeDiff = cameraZoomRange.y - cameraZoomRange.x;
        
        UpdateZoomSlider(defaultCameraZoomPercentage);
    }

    void Start()
    {
        CreateScaleGesture();
    }

    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (!Mathf.Approximately(scroll, 0f))
        {
            UpdateZoomSlider(cameraZoomSlider.value + (scroll * zoomScrollWheelSpeed * Time.deltaTime));
        }
    }

    void UpdateTimeScale(int stepIndex)
    {
        timeScaleStepIndex = Mathf.Clamp(stepIndex, 0, timeScaleSteps.Length - 1);
        Time.timeScale = timeScaleSteps[timeScaleStepIndex];
        timeScaleText.text = Time.timeScale.ToString();
    }
    
    void UpdateZoomSlider(float value)
    {
        cameraZoomSlider.value = value;
    }
    
    void UpdateCameraZoom(float zoomPercentage)
    {
        var zoom = cameraZoomRange.x + (zoomCurve.Evaluate(zoomPercentage) * cameraZoomRangeDiff);
        WorldCamera.Instance.SetZoom(zoom);
    }
    
    void ScaleGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            UpdateZoomSlider(cameraZoomSlider.value * scaleGesture.ScaleMultiplier);
        }
    }

    void CreateScaleGesture()
    {
        scaleGesture = new ScaleGestureRecognizer();
        scaleGesture.StateUpdated += ScaleGestureCallback;
        scaleGesture.ZoomSpeed = pinchZoomSpeed;
        FingersScript.Instance.AddGesture(scaleGesture);
    }
    
    public void UGUI_HandleResetButtonClick()
    {
        UpdateTimeScale(defaultTimeScaleStepIndex);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
    public void UGUI_HandleTimeScaleDecreaseButtonClick()
    {
        UpdateTimeScale(timeScaleStepIndex - 1);
    }
    
    public void UGUI_HandleTimeScaleIncreaseButtonClick()
    {
        UpdateTimeScale(timeScaleStepIndex + 1);
    }
    
    public void UGUI_HandleZoomSliderValueChange()
    {
        UpdateCameraZoom(cameraZoomSlider.value);
    }
}
