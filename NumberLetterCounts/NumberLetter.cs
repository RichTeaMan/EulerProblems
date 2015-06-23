using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberLetterCounts
{
    public static class NumberLetter
    {
        public static string[] unitWords =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
        };

        public static string[] teenWords =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen",
        };

        public static string[] tensWords =
        {
            "zero",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety",
        };

        public static string Letters(this int number)
        {
            if(number > 9999 || number < 1)
            {
                throw new ArgumentException("Number not supported.");
            }

            var thousands = getThousandLetters(number);
            var hundred = getHundredLetters(number);
            var tensAndUnit = getTenAndUnitLetters(number);

            var joiner = string.Empty;
            if((!string.IsNullOrWhiteSpace(thousands) || !string.IsNullOrWhiteSpace(hundred)) &&
                !string.IsNullOrWhiteSpace(tensAndUnit)
                )
            {
                joiner = "and";
            }

            var result = string.Concat(thousands, hundred, joiner, tensAndUnit);
            return result;
        }

        public static string getThousandLetters(int number)
        {
            var result = string.Empty;
            var thouDigit = getDigit(number, Digit.Thousands);
            if (thouDigit >= 1)
            {
                var multiName = getDigitName(thouDigit);
                result = string.Format("{0}thousand", multiName);
            }
            return result;
        }

        public static string getHundredLetters(int number)
        {
            var result = string.Empty;
            var hunDigit = getDigit(number, Digit.Hundred);
            if (hunDigit >= 1)
            {
                var multiName = getDigitName(hunDigit);
                result = string.Format("{0}hundred", multiName);
            }
            return result;
        }

        public static string getTenAndUnitLetters(int number)
        {
            string result = string.Empty;
            var tensDigit = getDigit(number, Digit.Tens);
            if (tensDigit >= 2)
            {
                var multiName = getTensName(tensDigit);

                var unit = getUnitLetters(number);
                result = string.Format("{0}{1}", multiName, unit);
            }
            else if(tensDigit >= 1)
            {
                var unit = getDigit(number, Digit.Units);
                result = teenWords[unit];
            }
            else
            {
                result = getUnitLetters(number);
            }
            return result;
        }

        public static string getUnitLetters(int number)
        {
            var result = string.Empty;
            if (number > 0)
            {
                var unit = getDigit(number, Digit.Units);
                if (unit > 0)
                {
                    var unitName = getDigitName(unit);
                    result = unitName;
                }
            }
            return result;
        }

        private static string getDigitName(int digit)
        {
            if(digit >= 0 && digit <= 9)
            {
                return unitWords[digit];
            }
            else
            {
                throw new ArgumentException("Invalid numbers.");
            }
        }

        private static string getTensName(int digit)
        {
            if (digit >= 0 && digit <= 9)
            {
                return tensWords[digit];
            }
            else
            {
                throw new ArgumentException("Invalid numbers.");
            }
        }

        public enum Digit
        {
            Units = 0,
            Tens = 1,
            Hundred = 2,
            Thousands = 3,
        }


        public static int getDigit(int number, Digit digit)
        {
            var chars = number.ToString().ToCharArray();
            if(chars.Length <= (int)digit)
            {
                return 0;
            }
            else
            {
                var pos = (chars.Length - (int)digit) - 1;
                var c = chars[pos];
                int result = int.Parse(c.ToString());
                return result;
            }
        }


    }
}
