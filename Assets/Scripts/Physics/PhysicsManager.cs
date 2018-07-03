using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : BehaviourSingleton<PhysicsManager>
{
    const float G = 0.00000000006673f; // 6.673×10-11
    const float GravityViewForceLimit = 1 / 4f;
    
    Dictionary<string, PhysicsEntity> entities = new Dictionary<string, PhysicsEntity>();
    
    void FixedUpdate()
    {
        foreach (var a in entities.Values)
        {
            foreach (var b in entities.Values)
            {
                if (a != b)
                {
                    a.AddForce(CalculateGravitationalForce(a, b));
                }
            }
        }
        
        foreach (var e in entities.Values)
        {
            e.Step(Time.fixedDeltaTime);
        }
    }
    
    public void Register(PhysicsEntity entity)
    {
        Debug.Assert(entity && !entities.ContainsKey(entity.GetId()));
        entities.Add(entity.GetId(), entity);
    }
    
    public void Deregister(PhysicsEntity entity)
    {
        Debug.Assert(entity && entities.ContainsKey(entity.GetId()));
        entities.Remove(entity.GetId());
    }
    
    public PhysicsEntity GetEntity(string id)
    {
        Debug.Assert(entities.ContainsKey(id));
        return entities[id];
    }
    
    public static Vector2 CalculateGravitationalForce(PhysicsEntity a, PhysicsEntity b)
    {
        return CalculateGravitationalForce(a.GetPosition(), a.GetMass(), b.GetPosition(), b.GetMass());
    }
    
    public static Vector2 CalculateGravitationalForce(Vector2 posA, float massA, Vector2 posB, float massB)
    {
        var diff = posB - posA;
        var distSquared = diff.sqrMagnitude;
        var dir = diff.normalized;
        var force = G * ((massB * massA) / distSquared);
        return dir * force;
    }
    
    public static float CalculateDistance(PhysicsEntity a, PhysicsEntity b, float gravitationalForceMagnitude)
    {
        return Mathf.Sqrt(G * ((b.GetMass() * a.GetMass()) / gravitationalForceMagnitude));
    }
}
