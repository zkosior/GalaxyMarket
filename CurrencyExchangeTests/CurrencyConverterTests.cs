using CurrencyExchange;
using NUnit.Framework;
using System;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class CurrencyConverterTests
    {
        [Test]
        public void ConvertsSingleRegisteredIntergalacticUnitToRomanNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual("I", new CurrencyConverter(definitions).Convert("glob"));
        }

        [Test]
        public void WhenIntergalacticNotRegistered_Throws()
        {
            var definitions = InitializeDefinitions();
            Assert.Throws<AggregateException>(() => new CurrencyConverter(definitions).Convert("asdf"));
        }

        private CurrencyDefinition InitializeDefinitions()
        {
            var definitions = new CurrencyDefinition();
            definitions.AddDefinition("glob", Roman.I);
            definitions.AddDefinition("prok", Roman.V);
            definitions.AddDefinition("pish", Roman.X);
            definitions.AddDefinition("tegj", Roman.L);

            return definitions;
        }
    }
}