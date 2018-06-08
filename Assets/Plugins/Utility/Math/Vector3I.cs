using System;

[Serializable]
public struct Vector3I
{
    public int x;
    public int y;
    public int z;

    public Vector3I(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString()
    {
        return string.Format("[{0},{1},{2}]", x, y, z);
    }

    public override bool Equals(object obj)
    {
        return obj is Vector3I && this == (Vector3I)obj;
    }

    public override int GetHashCode()
    {   
        return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2;
    }

    public static bool operator ==(Vector3I a, Vector3I b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }

    public static bool operator !=(Vector3I a, Vector3I b)
    {
        return !(a == b);
    }
}
