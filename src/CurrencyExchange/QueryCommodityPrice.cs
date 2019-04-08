namespace GalaxyMarket.CurrencyExchange
{
	using System.Linq;

	public class QueryCommodityPrice : ILanguageHandler
	{
		public QueryCommodityPrice(CommonMarket market)
		{
			this.Market = market;
		}

		private CommonMarket Market { get; }

		public bool TryHandle(string input, out string output)
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
						System.StringComparison.CurrentCultureIgnoreCase).TrimEnd();
					output = $"{amount} {commodity} is {this.Market.Query(commodity, amount):0.#} Credits";
					return true;
				}
			}

			output = string.Empty;
			return false;
		}
	}
}