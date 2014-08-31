using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = GetNumbers();
            double total = 0;
            foreach (var n in numbers)
            {
                total += n;
            }
            var result = total.ToString("F0").Substring(0, 10);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static double[] GetNumbers()
        {
            var numbers = new List<double>();

            using (var file = File.OpenText("Numbers.txt"))
            {
                string line = null;
                while ((line = file.ReadLine()) != null)
                {
                    var number = double.Parse(line);
                    
                    numbers.Add(number);
                }
            }
            return numbers.ToArray();
        }
    }
}
