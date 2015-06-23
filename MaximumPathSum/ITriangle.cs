using System.Collections.Generic;

namespace MaximumPathSum
{
    public interface ITriangle
    {
        IReadOnlyCollection<ITriangleRow> Rows { get; }

        ITriangleRow GetBottomRow();
    }
}