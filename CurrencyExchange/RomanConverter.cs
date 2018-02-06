using System;
using System.Collections.Generic;

namespace CurrencyExchange
{
    public static class RomanConverter
    {
        private static List<KeyValuePair<string, int>> romanNumerals = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("MM", 2000),
            new KeyValuePair<string, int>("MCM", 1900),
            new KeyValuePair<string, int>("M", 1000),
            new KeyValuePair<string, int>("CM", 900),
            new KeyValuePair<string, int>("D", 500),
            new KeyValuePair<string, int>("CD", 400),
            new KeyValuePair<string, int>("CC", 200),
            new KeyValuePair<string, int>("CXC", 190),
            new KeyValuePair<string, int>("C", 100),
            new KeyValuePair<string, int>("XC", 90),
            new KeyValuePair<string, int>("L", 50),
            new KeyValuePair<string, int>("XL", 40),
            new KeyValuePair<string, int>("XX", 20),
            new KeyValuePair<string, int>("XIX", 19),
            new KeyValuePair<string, int>("X", 10),
            new KeyValuePair<string, int>("IX", 9),
            new KeyValuePair<string, int>("V", 5),
            new KeyValuePair<string, int>("IV", 4),
            new KeyValuePair<string, int>("II", 2),
            new KeyValuePair<string, int>("I", 1)
    };

        public static int ToArabic(string romanAmount)
        {
            var result = 0;
            var romanToConvert = romanAmount;

            foreach (var romanDefinition in romanNumerals)
            {
                if (romanToConvert.StartsWith(romanDefinition.Key))
                {
                    result += romanDefinition.Value;
                    romanToConvert = romanToConvert.Substring(romanDefinition.Key.Length);
                }
            }

            if (romanToConvert.Length > 0)
            {
                throw new ArgumentException($"Roman numeral not supported: {romanAmount}");
            }

            return result;
        }
    }
}