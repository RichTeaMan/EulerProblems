using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonAbundantSums
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get all abundant numbers
            Console.WriteLine("Getting abundant numbers.");
            var abNums = GetAbundantNumbers();
            var results = new ConcurrentBag<int>();
            Console.WriteLine("Processing sums of abundant numbers.");
            Parallel.ForEach(Enumerable.Range(1, 28122), n =>
            {
                int mid = (int)Math.Floor(n / 2.0) + 1;
                bool exp = false;
                foreach (var i in abNums.Where(abNum => abNum <= mid))
                {
                    int remainder = n - i;
                    if (abNums.Contains(remainder))
                    {
                        exp = true;
                        break;
                    }
                }
                if (!exp)
                {
                    results.Add(n);
                }
            });

            foreach (var r in results.OrderBy(v => v))
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("Result: {0}", results.Sum());
            Console.ReadKey();
        }

        private static HashSet<int> GetAbundantNumbers()
        {
            ConcurrentBag<int> conAbNums = new ConcurrentBag<int>();
            Parallel.ForEach(Enumerable.Range(2, 28122), n =>
            {
                var divs = GetDivisors(n);
                var sum = divs.Where(num => num != n).Sum();
                if (sum > n)
                    conAbNums.Add(n);
            });
            var abNums = new HashSet<int>(conAbNums.OrderBy(v => v));
            return abNums;
        }

        static IList<int> GetDivisors(int number)
        {
            var result = new List<int>();
            if (number > 1)
            {
                var d_number = (double)number;
                double current = Math.Floor(d_number / 2) + 1;
                while (current > 0)
                {
                    if (d_number % current == 0)
                        result.Add((int)current);
                    current--;
                }
            }
            if (number == 1)
                result.Add(1);
            return result;
        }
    }
}
