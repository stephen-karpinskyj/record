using UnityEngine;

public class PositioningSignal : MonoBehaviour
{
    EntitySnapshot entity;

    public void Initialise(EntitySnapshot entity)
    {
        this.entity = entity;
    }
    
    public PositioningSignalSnapshot Snapshot()
    {
        return new PositioningSignalSnapshot
        {
            entity = entity,
        };
    }
}
