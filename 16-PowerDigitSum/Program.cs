using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PowerDigitSum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger v = new BigInteger(2);
            v = BigInteger.Pow(v, 1000);
            var str = v.ToString("F0");
            var result = str.Select(c => int.Parse(c.ToString())).Sum();
            Console.WriteLine("2^1000 = {0}", str);
            Console.WriteLine("Answer: {0}", result);
            Console.ReadKey();
        }
    }
}
