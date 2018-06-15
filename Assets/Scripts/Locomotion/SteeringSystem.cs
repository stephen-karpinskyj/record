using UnityEngine;

public class SteeringSystem : MonoBehaviour
{
    [SerializeField]
    Vector2 angleRange = new Vector2(-35f, 35f);
    
    [SerializeField]
    Transform[] wheels;
    
    [SerializeField]
    float lerpSpeed = 5f;
    
    float angle;
    float targetAngle;

    void FixedUpdate()
    {
        angle = Mathf.Lerp(angle, targetAngle, Time.fixedDeltaTime * lerpSpeed);
        
        foreach (var wheel in wheels)
        {
            wheel.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public float GetAngle()
    {
        return angle;
    }
    
    public void SetAngle(float newAngle)
    {
        targetAngle = Mathf.Clamp(newAngle, angleRange.x, angleRange.y);
        Debug.Log("SetAngle: " + targetAngle);
    }
}
