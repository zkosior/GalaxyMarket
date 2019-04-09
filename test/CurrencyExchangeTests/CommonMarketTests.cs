namespace GalaxyMarket.CurrencyExchangeTests
{
	using GalaxyMarket.CurrencyExchange.Converters;
	using GalaxyMarket.CurrencyExchange.Market;
	using NUnit.Framework;

	[TestFixture]
	public class CommonMarketTests
	{
		[Test]
		public void RegisteredProductWithIntergalacticUnits_GetsConvertedToArabic()
		{
			var market = new CommonMarket();
			market.Add("Silver", 2, 34);

			Assert.AreEqual(68, market.Query("Silver", 4));
		}

		[Test]
		public void RegisteredProducts_CanBeQueriedForPrice()
		{
			var market = new CommonMarket();
			market.Add("Gold", 4, 57800);
			market.Add("Iron", 20, 3910);

			Assert.AreEqual(57800, market.Query("Gold", 4));
			Assert.AreEqual(782, market.Query("Iron", 4));
		}
	}
}