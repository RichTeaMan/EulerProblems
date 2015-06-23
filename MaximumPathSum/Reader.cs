using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSum
{
    public abstract class Reader
    {
        private Triangle triangle;

        protected Reader()
        {
            triangle = new Triangle();
        }

        protected ITriangleRow AddRow(params int[] numbers)
        {
            if(triangle.Rows.Count + 1 == numbers.Length)
            {
                throw new InvalidOperationException("Row has incorrect amount of numbers.");
            }

            var row = new TriangleRow();

            foreach(var n in numbers)
            {
                new TrianglePart(n);
            }

            return row;
        }
    }
}
