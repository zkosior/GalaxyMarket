using CurrencyExchange;
using NUnit.Framework;
using System;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class CurrencyDefinitionTests
    {
        [Test]
        public void WhenUnitDefinitionAdded_ConvertsToRoman()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", "I");

            Assert.AreEqual("I", currencyDefinition["glob"]);
        }

        [Test]
        public void WhenRomanNumeralValueAlreadyRegistered_Throws()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob1", "I");
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob2", "I"));
        }

        [Test]
        public void WhenIntergalacticUnitAlreadyRegistered_Throws()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", "I");
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", "V"));
        }

        [Test]
        public void CoversAllSimpleRomanNumerals()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", "I");
            currencyDefinition.AddDefinition("prok", "V");
            currencyDefinition.AddDefinition("pish", "X");
            currencyDefinition.AddDefinition("tegj", "L");
            currencyDefinition.AddDefinition("asdf", "C");
            currencyDefinition.AddDefinition("zxcv", "D");
            currencyDefinition.AddDefinition("rfvb", "M");

            Assert.AreEqual("I", currencyDefinition["glob"]);
            Assert.AreEqual("V", currencyDefinition["prok"]);
            Assert.AreEqual("X", currencyDefinition["pish"]);
            Assert.AreEqual("L", currencyDefinition["tegj"]);
            Assert.AreEqual("C", currencyDefinition["asdf"]);
            Assert.AreEqual("D", currencyDefinition["zxcv"]);
            Assert.AreEqual("M", currencyDefinition["rfvb"]);
        }

        [Test]
        public void WhenUnitNotRegistered_Throws()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", "I");

            Assert.Throws<AggregateException>(() => { var a = currencyDefinition["prok"]; });
        }
    }
}