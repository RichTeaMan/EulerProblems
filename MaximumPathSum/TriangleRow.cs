using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSum
{
    public class TriangleRow : IReadOnlyCollection<ITrianglePart>, ITriangleRow
    {
        private List<ITrianglePart> parts;

        public TriangleRow()
        {
            parts = new List<ITrianglePart>();
        }

        public TriangleRow AddPart(TrianglePart part)
        {
            parts.Add(part);
            return this;
        }

        public int Count
        {
            get
            {
                return parts.Count;
            }
        }

        public IEnumerator<ITrianglePart> GetEnumerator()
        {
            return parts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return parts.GetEnumerator();
        }
    }
}
