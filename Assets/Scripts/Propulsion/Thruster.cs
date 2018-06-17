using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField]
    float force = 1f;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    ParticleSystem ps;
    
    [SerializeField]
    Vector2 throttleRange = new Vector2(0f, 1f);
    
    [SerializeField]
    Vector2 particleSizeRange = new Vector2(0f, 1f);

    [SerializeField]
    float lerpSpeed = 1f;
    
    float throttle;
    float targetThrottle;

    void FixedUpdate()
    {
        throttle = Mathf.Lerp(throttle, targetThrottle, Time.fixedDeltaTime * lerpSpeed);
        rb.AddForceAtPosition(-transform.up * force * throttle, transform.position);

        var main = ps.main;
        main.startSize = Mathf.Lerp(particleSizeRange.x, particleSizeRange.y, throttle);
    }
    
    public void SetThrottle(float newThrottle)
    {
        targetThrottle = Mathf.Clamp(newThrottle, throttleRange.x, throttleRange.y);
    }
}
