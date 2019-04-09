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
							this.market.Add(
								commodity,
								this.converter.ToArabic(
									components[0].Replace(
										commodity,
										string.Empty,
										StringComparison.CurrentCultureIgnoreCase).Trim()),
								price);
							output = null;
							return true;
						}
					}
				}
			}

			output = null;
			return false;
		}
	}
}