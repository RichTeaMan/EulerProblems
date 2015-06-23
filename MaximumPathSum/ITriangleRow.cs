using System.Collections.Generic;

namespace MaximumPathSum
{
    public interface ITriangleRow
    {
        int Count { get; }

        IEnumerator<ITrianglePart> GetEnumerator();
    }
}