namespace GalaxyMarket.CurrencyExchange.Market
{
	using System.Collections.Generic;

	public class CommonMarket
	{
		private readonly Dictionary<string, decimal> commodities =
			new Dictionary<string, decimal>();

		public void Add(string commodity, int amount, decimal price)
		{
			this.commodities.Add(commodity, price / amount);
		}

		public decimal Query(string commodity, int amount)
		{
			return this.commodities[commodity] * amount;
		}
	}
}