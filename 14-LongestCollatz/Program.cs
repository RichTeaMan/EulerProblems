using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCollatz
{
    class Program
    {
        static ConcurrentDictionary<long, long> cache;

        static void Main(string[] args)
        {
            cache = new ConcurrentDictionary<long, long>();
            var results = new ConcurrentDictionary<int, int>();
            Console.WriteLine("Processing data...");

            Parallel.ForEach(Enumerable.Range(2, 999998), start =>
            {
                long i = start;
                var d = new List<long>();
                int number = start;
                int steps = 1;
                while (i > 1)
                {
                    d.Add(i);
                    i = ProcessNumber(i);
                    steps++;
                }
                results.TryAdd(number, steps);
            });

            foreach (var result in results.OrderByDescending(r => r.Value).Take(100))
            {
                Console.WriteLine("n={0}, steps {1}", result.Key, result.Value);
            }
            Console.ReadKey();
        }

        static long ProcessNumber(long number)
        {
            long result = 0;
            if (!cache.TryGetValue(number, out result))
            {
                if (number % 2 == 0)
                    result = ProcessEven(number);
                else
                    result = ProcessOdd(number);
                cache.TryAdd(number, result);
            }
            return result;
        }

        static long ProcessOdd(long number)
        {
            return (number * 3) + 1;
        }

        static long ProcessEven(long number)
        {
            return number / 2;
        }
    }
}
