using System;

namespace CurrencyExchange
{
    public static class RomanConverter
    {
        public static int ToArabic(string romanAmount)
        {
            if (Enum.TryParse(romanAmount, out Roman arabic))
            {
                return (int)arabic;
            }

            throw new ArgumentException($"Roman numeral not supported: {romanAmount}");
        }
    }
}