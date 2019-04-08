namespace GalaxyMarket.CurrencyExchange.Market
{
	using System;
	using System.Collections.Generic;

	public class SymbolDefinition
	{
		private readonly Dictionary<string, string> definitions =
			new Dictionary<string, string>();

		private readonly List<string> whitelistedNumerals =
			new List<string> { "I", "V", "X", "L", "C", "D", "M" };

		public string this[string key] => this.definitions.ContainsKey(key)
			? this.definitions[key]
			: throw new ArgumentException(
				$"Intergalactic unit not registered: {key}");

		public void AddDefinition(string unit, string definition)
		{
			if (!this.whitelistedNumerals.Contains(definition))
			{
				throw new ArgumentException(
					$"Not supported Roman Numeral: {definition}");
			}

			if (this.definitions.ContainsKey(unit))
			{
				throw new ArgumentException(
					$"Intergalactic unit already registered: {unit}");
			}

			if (this.definitions.ContainsValue(definition))
			{
				throw new ArgumentException(
					$"Roman numeral already registered: {definition}");
			}

			this.definitions.Add(unit, definition);
		}

		public bool Contains(string unit)
		{
			return this.definitions.ContainsKey(unit);
		}
	}
}