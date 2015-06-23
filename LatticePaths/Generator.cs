using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatticePaths
{
    public class Generator
    {
        public static IEnumerable<bool[]> Sequence(int sequenceSize)
        {
            int skip = 64 - sequenceSize;
            long stop = (long)Math.Pow(2.0, sequenceSize);
            for (long i = 0; i < stop; i++)
            {
                var bools = BytesToBool(BitConverter.GetBytes(i));
                bools = bools.Take(sequenceSize).ToArray();
                yield return bools;
            }
        }

        private static bool[] BytesToBool(byte[] bytes)
        {
            var bools = new List<bool>();
            foreach (var b in bytes)
            {
                foreach (var bitNumber in Enumerable.Range(0, 8))
                {
                    bools.Add((b & (1 << bitNumber)) != 0);
                }
            }
            return bools.ToArray();
        }
    }
}
