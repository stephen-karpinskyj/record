public struct IdGenerator
{
    int currentId;

    public int Next()
    {
        return currentId++;
    }
}