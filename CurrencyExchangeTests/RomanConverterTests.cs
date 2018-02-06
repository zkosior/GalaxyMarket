using CurrencyExchange;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class RomanConverterTests
    {
        [Test]
        public void ConvertsSimpleRomanToArabic()
        {
            Assert.AreEqual(1, RomanConverter.ToArabic("I"));
        }

        [Test]
        public void ConvertsAllSimpleRomanToArabic()
        {
            Assert.AreEqual(1, RomanConverter.ToArabic("I"));
            Assert.AreEqual(5, RomanConverter.ToArabic("V"));
            Assert.AreEqual(10, RomanConverter.ToArabic("X"));
            Assert.AreEqual(50, RomanConverter.ToArabic("L"));
            Assert.AreEqual(100, RomanConverter.ToArabic("C"));
            Assert.AreEqual(500, RomanConverter.ToArabic("D"));
            Assert.AreEqual(1000, RomanConverter.ToArabic("M"));
        }

        [Test]
        public void WhenCalledOnUnsupportedNumeral_Throws()
        {
            Assert.Throws<ArgumentException>(() => RomanConverter.ToArabic("W"));
        }
    }
}