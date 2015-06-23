using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using NumberLetterCounts;

namespace NumberLetterCountsTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void getDigitTestOne()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(1, NumberLetterCounts.NumberLetter.Digit.Units);
            Assert.AreEqual(1, r);
        }

        [TestMethod]
        public void getDigitTestNine()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(9, NumberLetterCounts.NumberLetter.Digit.Units);
            Assert.AreEqual(9, r);
        }

        [TestMethod]
        public void getDigitTest10()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(10, NumberLetterCounts.NumberLetter.Digit.Units);
            Assert.AreEqual(0, r);
        }

        [TestMethod]
        public void getDigitTestFiftyFour()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(54, NumberLetterCounts.NumberLetter.Digit.Tens);
            Assert.AreEqual(5, r);
        }

        [TestMethod]
        public void getDigitTestThreeTwoOne()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(321, NumberLetterCounts.NumberLetter.Digit.Hundred);
            Assert.AreEqual(3, r);
        }

        [TestMethod]
        public void getDigitTestFourThreeTwoOne()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(4321, NumberLetterCounts.NumberLetter.Digit.Thousands);
            Assert.AreEqual(4, r);
        }

        [TestMethod]
        public void getDigitTestTwoOne()
        {
            var r = NumberLetterCounts.NumberLetter.getDigit(21, NumberLetterCounts.NumberLetter.Digit.Hundred);
            Assert.AreEqual(0, r);
        }

        [TestMethod]
        public void getThousandLetters()
        {
            foreach (var n in Enumerable.Range(1, 999))
            {
                Assert.AreEqual(
                    "",
                    NumberLetterCounts.NumberLetter.getThousandLetters(n),
                    "Tested " + n.ToString()
                    );
            }

            for (int i = 1; i < NumberLetterCounts.NumberLetter.unitWords.Length; i++)
            {
                var name = NumberLetterCounts.NumberLetter.unitWords[i];

                var result = string.Format("{0}thousand", name);
                foreach(var n in Enumerable.Range(i * 1000, 1000))
                {
                    Assert.AreEqual(
                        result,
                        NumberLetterCounts.NumberLetter.getThousandLetters(n),
                        "Tested " + n.ToString()
                        );
                }
            }
        }

        [TestMethod]
        public void getHundredLetters()
        {
            for (int i = 1; i < NumberLetterCounts.NumberLetter.unitWords.Length; i++)
            {
                var name = NumberLetterCounts.NumberLetter.unitWords[i];

                var result = string.Format("{0}hundred", name);
                foreach (var n in Enumerable.Range(i * 100, 100))
                {
                    Assert.AreEqual(
                        result,
                        NumberLetterCounts.NumberLetter.getHundredLetters(n),
                        "Tested " + n.ToString()
                        );
                }
            }
        }

        [TestMethod]
        public void getHundredLettersAbove999()
        {
            foreach (var n in Enumerable.Range(1000, 100))
            {
                Assert.AreEqual(
                    "",
                    NumberLetterCounts.NumberLetter.getHundredLetters(n),
                    "Tested " + n.ToString()
                    );
            }
            for (int i = 1; i < NumberLetterCounts.NumberLetter.unitWords.Length; i++)
            {
                var name = NumberLetterCounts.NumberLetter.unitWords[i];

                var result = string.Format("{0}hundred", name);
                foreach (var n in Enumerable.Range((i * 100) + 1000, 100))
                {
                    Assert.AreEqual(
                        result,
                        NumberLetterCounts.NumberLetter.getHundredLetters(n),
                        "Tested " + n.ToString()
                        );
                }
            }
        }

        [TestMethod]
        public void getTeenAndUnitLettersAboveNineteen()
        {
            foreach (var i in Enumerable.Range(2, 8))
            {
                var tenDigit = NumberLetterCounts.NumberLetter.getDigit(i * 10, NumberLetterCounts.NumberLetter.Digit.Tens);
                var tenDigitName = NumberLetterCounts.NumberLetter.tensWords[tenDigit];

                foreach (var n in Enumerable.Range(i * 10, 10))
                {
                    var unit = NumberLetterCounts.NumberLetter.getUnitLetters(n);
                    var expect = tenDigitName + unit;

                    var result = NumberLetterCounts.NumberLetter.getTenAndUnitLetters(n);

                    Assert.AreEqual(
                        expect,
                        result,
                        "Tested " + n.ToString()
                        );
                }
            }
        }

        [TestMethod]
        public void getTeenAndUnitLettersAboveTenBelowTwenty()
        {
            foreach (var i in Enumerable.Range(1, 9))
            {
                var expect = NumberLetterCounts.NumberLetter.teenWords[i];

                var result = NumberLetterCounts.NumberLetter.getTenAndUnitLetters(i + 10);

                Assert.AreEqual(
                    expect,
                    result,
                    "Tested " + i.ToString()
                    );
            }
        }

        [TestMethod]
        public void getUnitLetters()
        {
            for (int i = 1; i < NumberLetterCounts.NumberLetter.unitWords.Length; i++)
            {
                var name = NumberLetterCounts.NumberLetter.unitWords[i];

                var result = NumberLetterCounts.NumberLetter.getUnitLetters(i);

                Assert.AreEqual(
                    name,
                    result,
                    "Tested " + i.ToString()
                    );

            }
            Assert.AreEqual(
                "",
                NumberLetterCounts.NumberLetter.getUnitLetters(0),
                "Tested 0"
                );
        }

        [TestMethod]
        public void getLetters()
        {
            Assert.AreEqual("onethousandfivehundredandtwentythree", 1523.Letters());
            Assert.AreEqual("seventeen", 17.Letters());
            Assert.AreEqual("four", 4.Letters());
            Assert.AreEqual("ninehundred", 900.Letters());
            Assert.AreEqual("onethousand", 1000.Letters());
        }
    }
}
