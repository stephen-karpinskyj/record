using UnityEngine;

public class PhysicsEntity : MonoBehaviour
{
    [SerializeField]
    string id;
    
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float mass = 1f;

    [SerializeField]
    Vector2 initialVelocity = Vector2.zero;
    
    [SerializeField]
    float initialRotationalVelocity;
    
    [SerializeField]
    Transform centreOfMass;

    [SerializeField]
    Collider2D simulationCollider;
    
    Vector2 force;
    float torque;
    
    Vector2 velocity;
    float rotationalVelocity;
    
    void Awake()
    {
        velocity = initialVelocity;
        rotationalVelocity = initialRotationalVelocity;
        
        PhysicsManager.Instance.Register(this);
    }

    void OnDestroy()
    {
        if (PhysicsManager.Exists)
        {
            PhysicsManager.Instance.Deregister(this);
        }
    }

    public string GetId()
    {
        return id;
    }
    
    public float GetMass()
    {
        return mass;
    }

    public Vector2 GetPosition()
    {
        return centreOfMass.position;
    }
    
    public Vector2 GetVelocity()
    {
        return velocity;
    }
    
    public float GetRotationalVelocity()
    {
        return rotationalVelocity;
    }
    
    public void SetVelocity(Vector2 v)
    {
        velocity = v;
    }
    
    public void SetRotationalVelocity(float v)
    {
        rotationalVelocity = v;
    }
    
    public Collider2D GetSimulationCollider()
    {
        return simulationCollider;
    }
    
    public void AddForce(Vector2 f)
    {
        force += f;
    }
    
    public void AddTorque(float t)
    {
        torque += t;
    }

    public void Step(float deltaTime)
    {
        var acceleration = force / mass;
        velocity += acceleration * deltaTime;
        rb.MovePosition(rb.position + (velocity * deltaTime));
        
        var rotationalAcceleration = torque / mass;
        rotationalVelocity += rotationalAcceleration * deltaTime;
        rb.MoveRotation(rb.rotation + (rotationalVelocity * deltaTime));
        
        force = Vector2.zero;
        torque = 0f;
    }
}
