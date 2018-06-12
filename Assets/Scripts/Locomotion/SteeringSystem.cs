using UnityEngine;

public class SteeringSystem : MonoBehaviour
{
    [SerializeField]
    Vector2 angleRange = new Vector2(-35f, 35f);
    
    [SerializeField]
    Transform[] wheels;

    float angle;
    
    public float GetAngle()
    {
        return angle;
    }
    
    public void SetAngle(float newAngle)
    {
        // TODO: Lerp value
        angle = Mathf.Clamp(newAngle, angleRange.x, angleRange.y);
        Debug.Log("SetAngle: " + angle);
        
        foreach (var wheel in wheels)
        {
            wheel.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
