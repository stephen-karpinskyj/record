using System;
using UnityEngine;

[Serializable]
public struct PositioningSignalSnapshot
{
    public EntitySnapshot entity;

    public override string ToString()
    {
        return JsonUtility.ToJson(this, true);
    }
}
