using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSum
{
    public class Triangle : ITriangle
    {
        public IReadOnlyCollection<ITriangleRow> Rows { get; protected set; }

        public Triangle()
        {
            Rows = new List<TriangleRow>();
        }

        public ITriangleRow GetBottomRow()
        {
            return Rows.LastOrDefault();
        }
    }
}
