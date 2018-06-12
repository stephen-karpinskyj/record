using UnityEngine;

public class Drivetrain : MonoBehaviour
{
    [SerializeField]
    Engine engine;
    
    [SerializeField]
    SteeringSystem steering;
    
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float driveMagnitude = 2f;

    Transform t;
    
    void Awake()
    {
        t = rb.transform;
    }
    
    void FixedUpdate()
    {
        var power = engine.CalculatePower();
        var deltaPosition = (Vector2)t.up * engine.CalculatePower() * Time.fixedDeltaTime * driveMagnitude;
        rb.MovePosition(rb.position + deltaPosition);

        var sign = Mathf.Sign(power);
        var deltaRotation = sign * steering.GetAngle() * Time.fixedDeltaTime * driveMagnitude;
        rb.MoveRotation(rb.rotation + deltaRotation);
    }
}
