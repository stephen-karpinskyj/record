using System;
using UnityEngine;

[Serializable]
public struct EntitySnapshot
{
    public int id;
    public Vector2 position;
    
    public override string ToString()
    {
        return JsonUtility.ToJson(this, true);
    }
}
