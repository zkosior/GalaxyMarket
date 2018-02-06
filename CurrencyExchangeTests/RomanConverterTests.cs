using CurrencyExchange;
using NUnit.Framework;
using System;

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

        [Test]
        public void ConvertsAllSubtractedRomanToArabic()
        {
            Assert.AreEqual(4, RomanConverter.ToArabic("IV"));
            Assert.AreEqual(9, RomanConverter.ToArabic("IX"));
            Assert.AreEqual(40, RomanConverter.ToArabic("XL"));
            Assert.AreEqual(90, RomanConverter.ToArabic("XC"));
            Assert.AreEqual(400, RomanConverter.ToArabic("CD"));
            Assert.AreEqual(900, RomanConverter.ToArabic("CM"));
        }

        [Test]
        public void ConvertsSimpleRepetitions()
        {
            Assert.AreEqual(2, RomanConverter.ToArabic("II"));
            Assert.AreEqual(3, RomanConverter.ToArabic("III"));
            Assert.AreEqual(20, RomanConverter.ToArabic("XX"));
            Assert.AreEqual(30, RomanConverter.ToArabic("XXX"));
            Assert.AreEqual(200, RomanConverter.ToArabic("CC"));
            Assert.AreEqual(300, RomanConverter.ToArabic("CCC"));
            Assert.AreEqual(2000, RomanConverter.ToArabic("MM"));
            Assert.AreEqual(3000, RomanConverter.ToArabic("MMM"));
        }
    }
}