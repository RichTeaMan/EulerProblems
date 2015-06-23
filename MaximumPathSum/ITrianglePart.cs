namespace MaximumPathSum
{
    public interface ITrianglePart
    {
        ITrianglePart Top { get; }
        int Value { get; }
    }
}