using UnityEngine;

class SimulationEntity
{
    Vector2 position;

    public PhysicsEntity Entity;
    public Vector2 Force;
    public Vector2 Velocity;
    public Vector2 Position
    {
        get { return position; }
        set
        {
            position = value;
            var collider = Entity.GetSimulationCollider();
            if (collider)
            {
                collider.transform.position = value;
            }
        }
    }
}
