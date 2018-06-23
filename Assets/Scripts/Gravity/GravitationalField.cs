using UnityEngine;

public class GravitationalField : MonoBehaviour
{
    const float G = 0.00000000006673f; // 6.673×10-11
    
    [SerializeField]
    Rigidbody2D ship;

    [SerializeField]
    float mass = 1f;

    [SerializeField]
    GravitationalFieldView viewPrefab;

    GravitationalFieldView view;
    
    void Awake()
    {
        var force = 1 / 4f;
        var dist = Mathf.Sqrt((G * mass * ship.mass) / force);
        
        view = GameObjectUtility.InstantiatePrefab(viewPrefab, transform);
        view.SetScale(dist);
    }

    void FixedUpdate()
    {
        var diff = (Vector2)transform.position - ship.position;
        var distSquared = diff.sqrMagnitude;
        var dir = diff.normalized;
        var force = dir * ((G * mass * ship.mass) / distSquared);
        ship.AddForce(force);
    }
}
