using CurrencyExchange;
using NUnit.Framework;
using System;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class IntergalacticCurrencyConverterTests
    {
        [Test]
        public void ConvertsSingleRegisteredIntergalacticUnitToArabicNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual(1, new IntergalacticCurrencyConverter(definitions).ToArabic("glob"));
        }

        [Test]
        public void ConvertsComplexIntergalacticUnitToArabicNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual(2, new IntergalacticCurrencyConverter(definitions).ToArabic("glob glob"));
        }

        [Test]
        public void WhenIntergalacticNotRegistered_Throws()
        {
            var definitions = InitializeDefinitions();
            Assert.Throws<AggregateException>(() => new IntergalacticCurrencyConverter(definitions).ToArabic("asdf"));
        }

        [Test]
        public void ConvertsComplexIntergalacticUnitToArabicNumeral_ExampleFromInstrunctions()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual(42, new IntergalacticCurrencyConverter(definitions).ToArabic("pish tegj glob glob"));
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