using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_LexicographicPermutations
{
    public class Program
    {

        public static IEnumerable<long> GetPermutations(int[] digits)
        {
            //            The following algorithm generates the next permutation lexicographically after a given permutation. It changes the given permutation in-place.
            digits = digits.OrderBy(d => d).ToArray();
            var min = GetLongFromDigits(digits);
            var max = GetLongFromDigits(digits.OrderByDescending(d => d));

            long current = min;
            yield return min;

            while (current < max)
            {

                //Find the largest index k such that a[k] < a[k + 1].If no such index exists, the permutation is the last permutation.
                int kLarge = -1;
                for (var k = 0; k < digits.Length - 1; k++)
                {
                    if (digits[k] < digits[k + 1])
                    {
                        kLarge = k;
                    }
                }
                if (kLarge > -1)
                {

                    //Find the largest index l greater than k such that a[k] < a[l].
                    int lLarge = -1;
                    for (var l = 0; l < digits.Length; l++)
                    {
                        if (digits[kLarge] < digits[l])
                        {
                            lLarge = l;
                        }
                    }
                    if (lLarge > -1)
                    {
                        //Swap the value of a[k] with that of a[l].
                        int swap = digits[kLarge];
                        digits[kLarge] = digits[lLarge];
                        digits[lLarge] = swap;

                        //Reverse the sequence from a[k + 1] up to and including the final element a[n].
                        var reverse = digits.Skip(kLarge + 1).Reverse().ToArray();
                        for (int rI = 0, i = kLarge + 1; rI < reverse.Length; rI++, i++)
                        {
                            digits[i] = reverse[rI];
                        }

                        current = GetLongFromDigits(digits);
                    }
                    else
                    {
                        throw new InvalidOperationException("L index is invalid.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("K index is invalid.");
                }
                current = GetLongFromDigits(digits);
                yield return current;
            }


        }

        public static long GetLongFromDigits(IEnumerable<int> digits)
        {
            return GetLongFromDigits(digits.ToArray());
        }

        public static long GetLongFromDigits(params int[] digits)
        {
            long value = 0;
            foreach(var d in digits)
            {
                value *= 10;
                value += d;
            }
            return value;
        }

        static void Main(string[] args)
        {
            var digits = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = GetPermutations(digits).ElementAt(1000000 - 1);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
