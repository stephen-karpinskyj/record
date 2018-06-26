using UnityEngine;

public class PathSimulator : MonoBehaviour
{
    const float G = GravitationalField.G;
    
    [Header("Line")]
    
    [SerializeField]
    Rigidbody2D myBody;

    [SerializeField]
    GravitationalField otherBody;

    [SerializeField]
    int numSteps = 100;
    
    [SerializeField]
    LineRenderer line;

    [Header("Collision")]
    
    [SerializeField]
    CircleCollider2D otherCollider;

    [SerializeField]
    Transform collisionView;

    Vector3[] points;
    
    void Awake()
    {
        points = new Vector3[numSteps];
    }

    void Update()
    {
        Vector2 collisionPos;
        collisionView.localScale = Vector3.zero;
        
        var pos = myBody.position;
        var vel = myBody.velocity;

        points[0] = pos;

        var i = 1;
        while (i < points.Length)
        {
            var diff = otherBody.GetPosition() - pos;
            var distSquared = diff.sqrMagnitude;
            var dir = diff.normalized;
            var force = dir * ((G * otherBody.GetMass() * myBody.mass) / distSquared);

            var tempPos = pos;
            pos += (vel + force);
            
            if (CheckCollision(tempPos, pos, out collisionPos))
            {
                points[i++] = collisionPos;
                collisionView.position = collisionPos;
                collisionView.localScale = Vector3.one;
                break;
            }
            
            vel = pos - tempPos;
            points[i++] = pos;
        }

        line.positionCount = i;
        line.SetPositions(points);
    }

    bool CheckCollision(Vector2 a, Vector2 b, out Vector2 collisionPos)
    {
        var diff = b - a;
        var dist = diff.magnitude;
        var dir = diff.normalized;
        
        var layerMask = LayerMask.GetMask(LayerMask.LayerToName(otherCollider.gameObject.layer));
        var hit = Physics2D.Raycast(a, dir, dist, layerMask);
        
        if (hit.collider == otherCollider)
        {
            collisionPos = hit.point;
            return true;
        }
        
        collisionPos = Vector2.zero;
        return false;
    }
}
