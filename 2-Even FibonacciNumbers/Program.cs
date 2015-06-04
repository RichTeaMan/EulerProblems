using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Even_FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Fibonacci(4000000).Where(n => n % 2 == 0).Sum();
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static IEnumerable<int> Fibonacci(int max)
        {
            int a = 1;
            int b = 2;

            yield return a;
            yield return b;

            while(b < max)
            {
                int c = a + b;
                a = b;
                b = c;
                yield return c;
            }
        }
    }
}
