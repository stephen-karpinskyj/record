﻿using System;

[Serializable]
public struct Vector2I
{
    public int x;
    public int y;

    public Vector2I(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return string.Format("[{0},{1}]", x, y);
    }

    public override bool Equals(object obj)
    {
        return obj is Vector2I && this == (Vector2I)obj;
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode() << 2;
    }

    public static bool operator ==(Vector2I a, Vector2I b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Vector2I a, Vector2I b)
    {
        return !(a == b);
    }

    public static Vector2I operator *(Vector2I v, int scalar)
    {
        v.x *= scalar;
        v.y *= scalar;
        return v;
    }

    public static Vector2I operator /(Vector2I v, int scalar)
    {
        v.x /= scalar;
        v.y /= scalar;
        return v;
    }

    public bool SharesAxisWith(Vector2I a)
    {
        return x == a.x || y == a.y;
    }

    public bool SharesAxisWith(Vector2I a, Vector2I b)
    {
        if (a.x == b.x)
        {
            return x == a.x;
        }

        if (a.y == b.y)
        {
            return y == a.y;
        }

        return false;
    }
}
