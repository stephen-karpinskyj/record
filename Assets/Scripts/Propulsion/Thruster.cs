using UnityEngine;

public class Thruster : MonoBehaviour
{
    [SerializeField]
    float force = 1f;
    
    [SerializeField]
    float torque;

    [SerializeField]
    string entityId;

    [SerializeField]
    ParticleSystem ps;
    
    [SerializeField]
    Vector2 throttleRange = new Vector2(0f, 1f);
    
    [SerializeField]
    Vector2 particleSizeRange = new Vector2(0f, 1f);

    [SerializeField]
    float lerpSpeed = 1f;

    PhysicsEntity entity;
    
    float throttle;
    float targetThrottle;

    void Start()
    {
        entity = PhysicsManager.Instance.GetEntity(entityId);
    }

    void FixedUpdate()
    {
        throttle = Mathf.Lerp(throttle, targetThrottle, Time.fixedDeltaTime * lerpSpeed);
        entity.AddForce(-transform.up * force * throttle);
        entity.AddTorque(torque * throttle);

        if (ps)
        {
            var main = ps.main;
            main.startSize = Mathf.Lerp(particleSizeRange.x, particleSizeRange.y, throttle);
        }
    }
    
    public void SetThrottle(float newThrottle)
    {
        targetThrottle = Mathf.Clamp(newThrottle, throttleRange.x, throttleRange.y);
    }
}
