using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    float[] timeScaleSteps = { 0.25f, 0.5f, 1f, 2f, 5f, 15f, 30f, 60f };

    [SerializeField]
    int defaultTimeScaleStepIndex = 2;
    
    [SerializeField]
    Text timeScaleText;
    
    [SerializeField]
    Slider zoomSlider;
    
    [SerializeField]
    Camera worldCamera;

    int timeScaleStepIndex;

    void Awake()
    {
        timeScaleStepIndex = defaultTimeScaleStepIndex;
    }

    void UpdateTimescale(int stepIndex)
    {
        timeScaleStepIndex = Mathf.Clamp(stepIndex, 0, timeScaleSteps.Length - 1);
        Time.timeScale = timeScaleSteps[timeScaleStepIndex];
        timeScaleText.text = Time.timeScale.ToString();
    }
    
    public void UGUI_HandleResetButtonClick()
    {
        UpdateTimescale(defaultTimeScaleStepIndex);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
    public void UGUI_HandleTimeScaleDecreaseButtonClick()
    {
        UpdateTimescale(timeScaleStepIndex - 1);
    }
    
    public void UGUI_HandleTimeScaleIncreaseButtonClick()
    {
        UpdateTimescale(timeScaleStepIndex + 1);
    }
    
    public void UGUI_HandleZoomSliderValueChange()
    {
        worldCamera.orthographicSize = zoomSlider.value;
    }
}
