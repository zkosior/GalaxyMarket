namespace GalaxyMarket.CurrencyExchange.Handlers
{
	using GalaxyMarket.CurrencyExchange.Converters;
	using GalaxyMarket.CurrencyExchange.Market;
	using System;
	using System.Linq;

	public class QueryCommodityPrice : ILanguageHandler
	{
		private readonly CommonMarket market;
		private readonly UnitConverter converter;

		public QueryCommodityPrice(
			CommonMarket market,
			UnitConverter converter)
		{
			this.market = market;
			this.converter = converter;
		}

		public bool TryHandle(string input, out string output)
		{
			(string commodity, string amount) = ParseInputData(input);
			if (string.IsNullOrWhiteSpace(commodity) ||
				string.IsNullOrWhiteSpace(amount))
			{
				output = string.Empty;
				return false;
			}

			var commodityPrice = this.market.Query(commodity, this.converter.ToArabic(amount));

			output = $"{amount} {commodity} is {commodityPrice:0.#} Credits";
			return true;
		}

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

		private static (string comodity, string amount) ParseInputData(string input)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2 && components[0] == "how many Credits")
			{
				var commodity = components[1].Split(" ").Last();
				if (char.IsUpper(commodity[0]))
				{
					var amount = components[1].Replace(
						commodity,
						string.Empty,
						StringComparison.InvariantCultureIgnoreCase).TrimEnd();

					return (commodity, amount);
				}
			}

			return (null, null);
		}
	}
}