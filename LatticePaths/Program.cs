using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatticePaths
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paths: {0}", GetPaths(20));
            Console.ReadKey();
        }

        public static int GetPaths(int gridSize)
        {
            var pathCount = Generator.Sequence(gridSize * 2).Count(s => s.Count(b => b) == gridSize);
            return pathCount;
        }
    }
}
