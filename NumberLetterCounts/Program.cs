using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberLetterCounts
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var i in Enumerable.Range(1, 1000))
            {
                Console.WriteLine("{0} {1}", i, i.Letters());
            }
            var sum = Enumerable.Range(1, 1000).Sum(i => i.Letters().Length);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
