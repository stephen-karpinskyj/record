using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    Vector2 throttleRange = new Vector2(-0.5f, 1f);
    
    [SerializeField]
    float maxPower = 100;

    [SerializeField]
    float lerpSpeed = 1f;
    
    float throttle;
    float targetThrottle;

    void FixedUpdate()
    {
        throttle = Mathf.Lerp(throttle, targetThrottle, Time.fixedDeltaTime * lerpSpeed);
    }

    public void SetThrottle(float newThrottle)
    {
        targetThrottle = Mathf.Clamp(newThrottle, throttleRange.x, throttleRange.y);
        Debug.Log("SetThrottle: " + targetThrottle);
    }
    
    public float CalculatePower()
    {
        return throttle * maxPower;
    }
}
