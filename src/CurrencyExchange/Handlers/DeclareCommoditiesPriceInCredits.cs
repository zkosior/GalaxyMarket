namespace GalaxyMarket.CurrencyExchange.Handlers
{
	using GalaxyMarket.CurrencyExchange.Converters;
	using GalaxyMarket.CurrencyExchange.Market;
	using System;
	using System.Linq;

	public class DeclareCommoditiesPriceInCredits : ILanguageHandler
	{
		private readonly CommonMarket market;
		private readonly UnitConverter converter;

		public DeclareCommoditiesPriceInCredits(
			CommonMarket market,
			UnitConverter converter)
		{
			this.market = market;
			this.converter = converter;
		}

		public bool TryHandle(string input, out string output)
		{
			output = null;
			(string commodity, string amount, int? price) = ParseInputData(input);
			if (string.IsNullOrWhiteSpace(commodity) ||
				string.IsNullOrWhiteSpace(amount) ||
				!price.HasValue)
			{
				return false;
			}

			this.market.Add(
				commodity,
				this.converter.ToArabic(amount),
				price.Value);

			return true;
		}

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

		private static (string commodity, string amount, int? price) ParseInputData(string input)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2)
			{
				var secondPart = components[1].Split(" ");
				if (secondPart.Length == 2 && secondPart[1] == "Credits")
				{
					var commodity = components[0].Split(" ").Last();
					if (char.IsUpper(commodity[0]))
					{
						if (int.TryParse(secondPart[0], out var price))
						{
							return (commodity,
									components[0].Replace(
										commodity,
										string.Empty,
										StringComparison.InvariantCultureIgnoreCase).Trim(),
									price);
						}
					}
				}
			}

			return (null, null, null);
		}
	}
}