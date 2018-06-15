using UnityEngine;

public static class MathUtility
{
    /// <remarks>Based on: http://forum.unity3d.com/threads/how-do-i-find-the-closest-point-on-a-line.340058/</remarks>
    public static Vector2 NearestPointOnLineSegment(Vector2 start, Vector2 end, Vector2 point)
    {
        var line = (end - start);
        var len = line.magnitude;
        line.Normalize();

        var v = point - start;
        var d = Vector3.Dot(v, line);
        d = Mathf.Clamp(d, 0f, len);
        return start + line * d;
    }

    /// <remarks>Based on: http://forum.unity3d.com/threads/moving-an-object-on-a-specific-arc.387757/</remarks>
    public static float CircleArcDistanceToAngleOffset(float distance, float circleRadius)
    {
        return (distance / circleRadius) * Mathf.Rad2Deg;
    }

    /// <remarks>Source: http://answers.unity3d.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html#answer-823216</remarks>
    public static Vector2 ToHeading(float degrees)
    {
        return Quaternion.AngleAxis(degrees, Vector3.forward) * Vector2.up;
    }

    public static float PercentBetween(float min, float max, float value)
    {
        return Mathf.Clamp01((value - min) / (max - min));
    }
    
    public static Vector3[] GenerateCircle(int pointCount, float radius, float z = 0f)
    {
        Debug.Assert(pointCount > 0);
        Debug.Assert(radius > 0f);

        var angleDelta = (360f / pointCount) * Mathf.Deg2Rad;
        var points = new Vector3[pointCount];

        var angle = 0f;
        for (var i = 0; i < pointCount; i++)
        {
            points[i] = new Vector3(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle), z);
            angle += angleDelta;
        }

        return points;
    }
}
