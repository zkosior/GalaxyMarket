using CurrencyExchange;
using NUnit.Framework;
using System;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class IntergalacticCurrencyConverterTests
    {
        [Test]
        public void ConvertsSingleRegisteredIntergalacticUnitToRomanNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual("I", new IntergalacticCurrencyConverter(definitions).ToRoman("glob"));
        }

        [Test]
        public void ConvertsComplexIntergalacticUnitToRomanNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual("II", new IntergalacticCurrencyConverter(definitions).ToRoman("glob glob"));
        }

        [Test]
        public void WhenIntergalacticNotRegistered_Throws()
        {
            var definitions = InitializeDefinitions();
            Assert.Throws<AggregateException>(() => new IntergalacticCurrencyConverter(definitions).ToRoman("asdf"));
        }

        private CurrencyDefinition InitializeDefinitions()
        {
            var definitions = new CurrencyDefinition();
            definitions.AddDefinition("glob", "I");
            definitions.AddDefinition("prok", "V");
            definitions.AddDefinition("pish", "X");
            definitions.AddDefinition("tegj", "L");

            return definitions;
        }
    }
}