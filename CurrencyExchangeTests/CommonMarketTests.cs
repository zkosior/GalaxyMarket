using CurrencyExchange;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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