namespace GalaxyMarket.CurrencyExchange.Handlers
{
	using GalaxyMarket.CurrencyExchange.Converters;
	using GalaxyMarket.CurrencyExchange.Market;
	using System;
	using System.Linq;

	public class QueryCommodityConversion : ILanguageHandler
	{
		private readonly UnitConverter converter;

		private readonly CommonMarket market;

		public QueryCommodityConversion(
			CommonMarket market,
			UnitConverter converter)
		{
			this.market = market;
			this.converter = converter;
		}

		public bool TryHandle(string input, out string output)
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2 &&
				components[0].StartsWith(
					"how many",
					StringComparison.InvariantCultureIgnoreCase))
			{
				var commodity1 = components[0].Split(" ").Last();
				var commodity2Split = components[1].Split(" ");
				var commodity2Amount = string.Join(" ", commodity2Split.SkipLast(1));
				var commodity2 = commodity2Split.Last();

				var commodity2Price = this.market.Query(
						commodity2,
						this.converter.ToArabic(commodity2Amount));
				var commodity1UnitPrice = this.market.Query(commodity1, 1);

				output = $"{commodity2Amount} {commodity2} is {commodity2Price / commodity1UnitPrice:0.#} {commodity1}";
				return true;
			}

			output = string.Empty;
			return false;
		}
	}
}