using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    [SerializeField]
    float collisionDampeningFactor = 0.7f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        var rb = collision.otherRigidbody;
        var entity = rb.GetComponentInChildren<PhysicsEntity>();
        var normal = collision.contacts[0].normal;
        var vel = entity.GetVelocity();
        var dir = vel.normalized;
        var reflectedDir = Vector2.Reflect(dir, normal);
        entity.SetVelocity(reflectedDir * vel.magnitude * collisionDampeningFactor);
        rb.isKinematic = false;
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        var rb = collision.otherRigidbody;
        rb.isKinematic = true;
    }
}
