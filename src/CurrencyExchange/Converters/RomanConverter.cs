namespace GalaxyMarket.CurrencyExchange.Converters
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class RomanConverter
	{
		private static readonly List<KeyValuePair<string, int>> RomanNumerals =
			new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("M", 1000),
				new KeyValuePair<string, int>("CM", 900),
				new KeyValuePair<string, int>("D", 500),
				new KeyValuePair<string, int>("CD", 400),
				new KeyValuePair<string, int>("CXC", 190),
				new KeyValuePair<string, int>("C", 100),
				new KeyValuePair<string, int>("XC", 90),
				new KeyValuePair<string, int>("L", 50),
				new KeyValuePair<string, int>("XL", 40),
				new KeyValuePair<string, int>("X", 10),
				new KeyValuePair<string, int>("IX", 9),
				new KeyValuePair<string, int>("V", 5),
				new KeyValuePair<string, int>("IV", 4),
				new KeyValuePair<string, int>("I", 1)
			};

		public static int ToArabic(string romanAmount)
		{
			VerifyCommonIssues(romanAmount);

			return SumEverything(romanAmount);
		}

		private static int SumEverything(string romanAmount)
		{
			var result = 0;
			var romanToConvert = romanAmount;

			foreach ((string symbol, int value) in RomanNumerals)
			{
				while (romanToConvert.StartsWith(
					symbol,
					StringComparison.InvariantCultureIgnoreCase))
				{
					result += value;
					romanToConvert = romanToConvert.Substring(symbol.Length);
				}
			}

			if (romanToConvert.Length > 0)
			{
				throw new ArgumentException($"Roman numeral not supported: {romanAmount}");
			}

			return result;
		}

		private static void VerifyCommonIssues(string romanAmount)
		{
			CheckUpToThree(romanAmount, 'M');
			CheckUpToThree(romanAmount, 'C');
			CheckUpToThree(romanAmount, 'X');
			CheckUpToThree(romanAmount, 'I');
			CheckSingle(romanAmount, "D", "CM");
			CheckSingle(romanAmount, "L", "XC");
			CheckSingle(romanAmount, "V", "IX");
			CheckForRemoveAndAdd(romanAmount);
		}

		private static void CheckUpToThree(string romanDigits, char digit)
		{
			if (romanDigits.Count(c => c == digit) > 3)
				throw new ArgumentException($"Too many Roman digits: {digit}");
		}

		private static void CheckSingle(string romanDigits, string special, string contra)
		{
			var ds = romanDigits.Split(special);
			if (ds.Length > 2) throw new ArgumentException($"Too many Roman digits: {special}");
			if (ds.Length == 2 &&
				romanDigits.Contains(
					contra,
					StringComparison.InvariantCultureIgnoreCase))
				throw new ArgumentException($"Incorrect combination: {contra}+{special}");
		}

		private static void CheckForRemoveAndAdd(string romanDigits)
		{
			SpecialCaseRemoveAndAdd(romanDigits, "CMC");
			SpecialCaseRemoveAndAdd(romanDigits, "CDC");
			SpecialCaseRemoveAndAdd(romanDigits, "XCX");
			SpecialCaseRemoveAndAdd(romanDigits, "XLX");
			SpecialCaseRemoveAndAdd(romanDigits, "IXI");
			SpecialCaseRemoveAndAdd(romanDigits, "IVI");
		}

		private static void SpecialCaseRemoveAndAdd(string romanDigits, string pattern)
		{
			if (romanDigits.Contains(pattern, StringComparison.InvariantCultureIgnoreCase))
				throw new ArgumentException($"Incorrect Roman numeral: {pattern}");
		}
	}
}