using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSum
{
    public class TrianglePart : ITrianglePart
    {
        public ITrianglePart Top { get; }

        public int Value { get; }

        public TrianglePart(int value, TrianglePart top):this(value)
        {
            Top = top;
        }

        public TrianglePart(int value) : this()
        {
            Value = value;
        }

        protected TrianglePart()
        { }
    }
}
