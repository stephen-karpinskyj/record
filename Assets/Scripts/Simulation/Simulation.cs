using UnityEngine;

public class Simulation : MonoBehaviour
{
    [SerializeField]
    string entityId;

    [SerializeField]
    string[] otherEntityIds;

    [SerializeField]
    string simulationLayer = "Simulation";

    [SerializeField]
    float timeInterval = 0.1f;

    [SerializeField]
    float duration = 1f;

    [SerializeField]
    float entityRadius = 3.5f;
    
    [SerializeField]
    LineRenderer line;

    [SerializeField]
    Transform collisionViewPrefab;

    SimulationEntity entity;
    SimulationEntity[] entities;
    Vector3[] points;
    Vector2 previousEntityPosition;
    Vector2 collisionPosition;
    Transform collisionView;
    
    void Awake()
    {
        var numSteps = Mathf.CeilToInt(duration / timeInterval);
        points = new Vector3[numSteps];
        
        collisionView = GameObjectUtility.InstantiatePrefab(collisionViewPrefab);
    }

    void Start()
    {
        entities = new SimulationEntity[otherEntityIds.Length + 1];
        
        var i = 0;
        for (i = 0; i < otherEntityIds.Length; i++) 
        {
            entities[i] = new SimulationEntity{ Entity = PhysicsManager.Instance.GetEntity(otherEntityIds[i]) };
        }
        
        entity = new SimulationEntity { Entity = PhysicsManager.Instance.GetEntity(entityId) };
        entities[i] = entity;
    }

    void Update()
    {
        ResetEntities();
        UpdateLinePoint(0);
        
        var i = 0;
        for (i = 1; i < points.Length; i++)
        {
            previousEntityPosition = entity.Position;

            ResetForces();
            CalculateForces();
            ApplyForces();
            
            if (CheckCollision())
            {
                HandleCollision(ref i);
                break;
            }
            
            UpdateLinePoint(i);
        }
        
        UpdateLine(i);
    }
    
    void ResetEntities()
    {
        collisionView.localScale = Vector3.zero;
        
        foreach (var e in entities)
        {
            e.Velocity = e.Entity.GetVelocity();
            e.Position = e.Entity.GetPosition();
        }
    }
    
    void ResetForces()
    {
        foreach (var e in entities)
        {
            e.Force = Vector2.zero;
        }
    }
    
    void CalculateForces()
    {
        foreach (var a in entities)
        {
            foreach (var b in entities)
            {
                if (a != b)
                {
                    a.Force += PhysicsManager.CalculateGravitationalForce(a.Position, a.Entity.GetMass(), b.Position, b.Entity.GetMass());
                }
            }
        }
    }
    
    void ApplyForces()
    {
        foreach (var e in entities)
        {
            var acceleration = e.Force / e.Entity.GetMass();
            e.Velocity += acceleration * timeInterval;
            e.Position += e.Velocity * timeInterval;
        }
    }
    
    bool CheckCollision()
    {
        var diff = entity.Position - previousEntityPosition;
        var dist = diff.magnitude;
        var dir = diff.normalized;

        var layerMask = LayerMask.GetMask(simulationLayer);
        var hit = Physics2D.CircleCast(previousEntityPosition, entityRadius, dir, dist, layerMask);

        if (hit.collider != entity.Entity.GetSimulationCollider())
        {
            collisionPosition = hit.centroid;
            return true;
        }

        return false;
    }
    
    void HandleCollision(ref int step)
    {
        points[step++] = collisionPosition;
        collisionView.position = collisionPosition;
        collisionView.localScale = Vector3.one;
    }
    
    void UpdateLinePoint(int step)
    {
        points[step] = entity.Position;
    }
    
    void UpdateLine(int pointCount)
    {
        line.positionCount = pointCount;
        line.SetPositions(points);
    }
}
