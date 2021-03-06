namespace GalaxyMarket.CurrencyExchange.Converters
{
	using GalaxyMarket.CurrencyExchange.Market;
	using System;
	using System.Collections.Generic;

	public class UnitConverter
	{
		private readonly SymbolDefinition definitions;

		public UnitConverter(SymbolDefinition definitions)
		{
			this.definitions = definitions;
		}

		public int ToArabic(string intergalacticAmount)
		{
			return RomanConverter.ToArabic(this.JoinOutput(intergalacticAmount));
		}

		private string JoinOutput(string intergalacticAmount)
		{
			return string.Join(string.Empty, this.ConvertToRoman(intergalacticAmount));
		}

		private IEnumerable<string> ConvertToRoman(string intergalacticAmount)
		{
			foreach (var unit in intergalacticAmount.Split(" "))
			{
				if (!this.definitions.Contains(unit))
				{
					throw new ArgumentException($"Not registered symbol: {nameof(intergalacticAmount)}");
				}

				yield return this.definitions[unit];
			}
		}
	}
}