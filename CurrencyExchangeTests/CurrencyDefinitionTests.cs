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
            currencyDefinition.AddDefinition("glob", Roman.I);

            Assert.AreEqual(Roman.I, currencyDefinition["glob"]);
        }

        [Test]
        public void WhenRomanNumeralValueAlreadyRegistered_Throws()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob1", Roman.I);
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob2", Roman.I));
        }

        [Test]
        public void WhenIntergalacticUnitAlreadyRegistered_Throws()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", Roman.I);
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.V));
        }

        [Test]
        public void CoversAllSimpleRomanNumerals()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", Roman.I);
            currencyDefinition.AddDefinition("prok", Roman.V);
            currencyDefinition.AddDefinition("pish", Roman.X);
            currencyDefinition.AddDefinition("tegj", Roman.L);
            currencyDefinition.AddDefinition("asdf", Roman.C);
            currencyDefinition.AddDefinition("zxcv", Roman.D);
            currencyDefinition.AddDefinition("rfvb", Roman.M);

            Assert.AreEqual(Roman.I, currencyDefinition["glob"]);
            Assert.AreEqual(Roman.V, currencyDefinition["prok"]);
            Assert.AreEqual(Roman.X, currencyDefinition["pish"]);
            Assert.AreEqual(Roman.L, currencyDefinition["tegj"]);
            Assert.AreEqual(Roman.C, currencyDefinition["asdf"]);
            Assert.AreEqual(Roman.D, currencyDefinition["zxcv"]);
            Assert.AreEqual(Roman.M, currencyDefinition["rfvb"]);
        }

        [Test]
        public void WhenUnitNotRegistered_Throws()
        {
            var currencyDefinition = new CurrencyDefinition();
            currencyDefinition.AddDefinition("glob", Roman.I);

            Assert.Throws<AggregateException>(() => { var a = currencyDefinition["prok"]; });
        }

        [Test]
        public void CanRegisterOnlySingleDigitRomanNumerals()
        {
            var currencyDefinition = new CurrencyDefinition();

            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.IV));
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.IX));
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.XL));
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.XC));
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.CD));
            Assert.Throws<AggregateException>(() => currencyDefinition.AddDefinition("glob", Roman.CM));
        }
    }
}