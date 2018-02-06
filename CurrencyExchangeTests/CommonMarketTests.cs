using CurrencyExchange;
using NUnit.Framework;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class CommonMarketTests
    {
        [Test]
        public void RegisteredProductWithIntergalactitUnits_GetsConvertedToArabic()
        {
            var definitions = this.InitializeDefinitions();
            var converter = new UnitConverter(definitions);
            var market = new CommonMarket(converter);
            market.Add("Silver", "glob glob", 34);

            Assert.AreEqual(68, market.Query("Silver", "glob prok"));
        }

        [Test]
        public void RegisteredProducts_CanBeQueriedForPrice()
        {
            var definitions = this.InitializeDefinitions();
            var converter = new UnitConverter(definitions);
            var market = new CommonMarket(converter);
            market.Add("Gold", "glob prok", 57800);
            market.Add("Iron", "pish pish", 3910);

            Assert.AreEqual(57800, market.Query("Gold", "glob prok"));
            Assert.AreEqual(782, market.Query("Iron", "glob prok"));
        }

        private SymbolDefinition InitializeDefinitions()
        {
            var definitions = new SymbolDefinition();
            definitions.AddDefinition("glob", "I");
            definitions.AddDefinition("prok", "V");
            definitions.AddDefinition("pish", "X");
            definitions.AddDefinition("tegj", "L");

            return definitions;
        }
    }
}