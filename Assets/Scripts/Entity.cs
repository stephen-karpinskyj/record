using UnityEngine;

public class Entity : MonoBehaviour
{
    static IdGenerator idGen;

    int id = idGen.Next();

    public EntitySnapshot Snapshot()
    {
        return new EntitySnapshot
        {
            id = id,
            position = transform.position,
        };
    }
}
