using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSUIWidget : MonoBehaviour
{
    [SerializeField]
    Text text;
    
    [SerializeField]
    float frequency = 0.5f; // The update frequency of the fps
	
    [SerializeField]
    int numDecimal = 1; // How many decimal do you want to display
 
    [SerializeField]
    float yellowFps = 50f;
    
    [SerializeField]
    float greenFps = 60f;

    [SerializeField]
    Color redColor = Color.red;

    [SerializeField]
    Color yellowColor = Color.yellow;

    [SerializeField]
    Color greenColor = Color.green;
 
	float accum; // FPS accumulated over the interval
	int frames; // Frames drawn over the interval
 
	void Awake()
	{
	    StartCoroutine(UpdateCoroutine());
	}
 
	void Update()
	{
	    accum += Time.timeScale / Time.deltaTime;
        frames++;
	}
 
	IEnumerator UpdateCoroutine()
	{
		while (true)
		{
            var start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + frequency)
            {
                yield return null;
            }
            
		    var fps = accum / frames;

		    text.text = fps.ToString("f" + Mathf.Clamp(numDecimal, 0, 10));
            text.color = (fps >= greenFps) ? greenColor : (fps >= yellowFps) ? yellowColor : redColor;
 
	        accum = 0f;
	        frames = 0;
		}
	}
}
