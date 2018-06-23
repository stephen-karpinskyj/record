using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    Vector2 timeScaleRange = new Vector2(0.01f, 1000f);

    [SerializeField]
    Text timeScaleText;
    
    [SerializeField]
    Slider zoomSlider;
    
    [SerializeField]
    Camera worldCamera;
    
    void UpdateTimescale(float timeScale)
    {
        Time.timeScale = Mathf.Clamp(timeScale, timeScaleRange.x, timeScaleRange.y);
        timeScaleText.text = Time.timeScale.ToString();
    }
    
    public void UGUI_HandleResetButtonClick()
    {
        UpdateTimescale(1f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
    public void UGUI_HandleTimeScaleDecreaseButtonClick()
    {
        UpdateTimescale(Time.timeScale / 10f);
    }
    
    public void UGUI_HandleTimeScaleIncreaseButtonClick()
    {
        UpdateTimescale(Time.timeScale * 10f);
    }
    
    public void UGUI_HandleZoomSliderValueChange()
    {
        worldCamera.orthographicSize = zoomSlider.value;
    }
}
