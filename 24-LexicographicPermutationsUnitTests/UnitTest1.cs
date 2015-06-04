using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace _24_LexicographicPermutationsUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetIntFromDigitsTest()
        {
            long numberCount = Math.BigMul(int.MaxValue, 2);
            for(long i = 0; i < numberCount; i++)
            {
                // get digits from number
                var digits = i.ToString().Select(s => int.Parse(s.ToString()));

                var value = _24_LexicographicPermutations.Program.GetLongFromDigits(digits);
                Assert.AreEqual(i, value);
            }

            // now do same with leading 0s
            for (long i = 0; i < numberCount; i++)
            {
                // get digits from number
                var digits = new[] { 0, 0, 0 }.Concat(i.ToString().Select(s => int.Parse(s.ToString())));
                

                var value = _24_LexicographicPermutations.Program.GetLongFromDigits(digits);
                Assert.AreEqual(i, value);
            }
        }

        [TestMethod]
        public void GetPermutationsTest()
        {
            var results = new[] { 012, 021, 102, 120, 201, 210 };
            var value = _24_LexicographicPermutations.Program.GetPermutations(new[] { 2, 1, 0 }).ToArray();
            Assert.AreEqual(results.Length, value.Count());

            for (var i = 0; i < results.Length; i++)
            {
                Assert.AreEqual(results[i], value[i]);
            }
        }
    }
}
