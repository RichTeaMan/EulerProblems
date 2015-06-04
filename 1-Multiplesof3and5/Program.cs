using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Multiplesof3and5
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Enumerable.Range(0, 1000).Where(n => n % 3 == 0 || n % 5 == 0).Sum();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
