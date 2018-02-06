using CurrencyExchange;
using NUnit.Framework;
using System;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class UnitConverterTests
    {
        [Test]
        public void ConvertsSingleRegisteredIntergalacticUnitToArabicNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual(1, new UnitConverter(definitions).ToArabic("glob"));
        }

        [Test]
        public void ConvertsComplexIntergalacticUnitToArabicNumeral()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual(2, new UnitConverter(definitions).ToArabic("glob glob"));
        }

        [Test]
        public void WhenIntergalacticNotRegistered_Throws()
        {
            var definitions = InitializeDefinitions();
            Assert.Throws<AggregateException>(() => new UnitConverter(definitions).ToArabic("asdf"));
        }

        [Test]
        public void ConvertsComplexIntergalacticUnitToArabicNumeral_ExampleFromInstrunctions()
        {
            var definitions = InitializeDefinitions();
            Assert.AreEqual(42, new UnitConverter(definitions).ToArabic("pish tegj glob glob"));
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