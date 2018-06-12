using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    Vector2 throttleRange = new Vector2(-0.5f, 1f);
    
    [SerializeField]
    float maxPower = 100;
    
    float throttle;

    public void SetThrottle(float newThrottle)
    {
        // TODO: Lerp value
        throttle = Mathf.Clamp(newThrottle, throttleRange.x, throttleRange.y);
        Debug.Log("SetThrottle: " + throttle);
    }
    
    public float CalculatePower()
    {
        return throttle * maxPower;
    }
}
