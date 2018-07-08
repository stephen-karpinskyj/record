using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    [SerializeField]
    Vector2 collisionDampeningRange = new Vector2(0.05f, 0.2f);
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        var rb = collision.otherRigidbody;
        var entity = rb.GetComponentInChildren<PhysicsEntity>();
        var normal = collision.contacts[0].normal;
        var vel = entity.GetVelocity();
        var dir = vel.normalized;
        var reflectedDir = Vector2.Reflect(dir, normal);
        var dampeningFactor = CalculateDampeningFactor(dir, reflectedDir);
        entity.SetVelocity(reflectedDir * vel.magnitude * dampeningFactor);
        rb.isKinematic = false;
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        var rb = collision.otherRigidbody;
        rb.isKinematic = true;
    }
    
    float CalculateDampeningFactor(Vector2 inDir, Vector2 outDir)
    {
        var t = (Vector2.Dot(inDir, outDir) + 1) / 2; // [0=parallel, 1=perpendicular]
        return (collisionDampeningRange.y - collisionDampeningRange.x) * t + collisionDampeningRange.x;
    }
}
