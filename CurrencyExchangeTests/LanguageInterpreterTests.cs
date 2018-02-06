using CurrencyExchange;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchangeTests
{
    [TestFixture]
    public class LanguageInterpreterTests
    {
        [Test]
        public void UnitDeclaration_DoesntProduceOutput()
        {
            Assert.IsNull(new LanguageInterpreter().Add("glob is I"));
        }

        [Test]
        public void QueryingForArabic_ReturnsConversionsBasedOnRegisteredSymbols()
        {
            var interpreter = new LanguageInterpreter();
            this.InitializeSymbols(interpreter);

            Assert.AreEqual("pish tegj glob glob is 42", interpreter.Add("how much is pish tegj glob glob ?"));
        }

        private void InitializeSymbols(LanguageInterpreter interpreter)
        {
            interpreter.Add("glob is I");
            interpreter.Add("prok is V");
            interpreter.Add("pish is X");
            interpreter.Add("tegj is L");
        }
    }
}