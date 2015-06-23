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

        public static long GetPaths(int gridSize)
        {
            long paths = 1;
            for (int i = 0; i < gridSize; i++)
            {
                paths *= (2 * gridSize) - i;
                paths /= i + 1;
            }
            return paths;
        }
    }
}
