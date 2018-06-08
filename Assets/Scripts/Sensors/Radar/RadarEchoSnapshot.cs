using System;
using UnityEngine;

[Serializable]
public struct RadarEchoSnapshot
{
    public EntitySnapshot originEntity;
    public Vector2 originPoint;
    public Vector2 contactPoint;

    public override string ToString()
    {
        return JsonUtility.ToJson(this, true);
    }
}
