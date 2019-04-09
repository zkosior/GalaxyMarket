namespace GalaxyMarket.CurrencyExchangeTests
{
	using DryIoc;
	using GalaxyMarket.CurrencyExchange;
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class LanguageInterpreterTests
	{
		[Test]
		public void UnitDeclaration_DoesNotProduceOutput()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			Assert.IsNull(interpreter.Add("glob is I"));
		}

		[Test]
		public void AddingCommodity_DoesNotProduceOutput()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			interpreter.Add("glob is I");
			Assert.IsNull(interpreter.Add("glob glob Silver is 34 Credits"));
		}

		[Test]
		public void QueryingForArabic_ReturnsConversionsBasedOnRegisteredSymbols()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			InitializeSymbols(interpreter);

			Assert.AreEqual(
				"pish tegj glob glob is 42",
				interpreter.Add("how much is pish tegj glob glob ?"));
		}

		[Test]
		public void QueryingForCommodity_ReturnsPriceOfChosenAmountOfSelectedProduct()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			InitializeSymbols(interpreter);
			InitializeCommodities(interpreter);

			Assert.AreEqual(
				"glob prok Silver is 68 Credits",
				interpreter.Add("how many Credits is glob prok Silver ?"));
		}

		[Test]
		public void UnknownQuery_ReceivesDefaultResponse()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			Assert.AreEqual(
				"I have no idea what you are talking about",
				interpreter.Add("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
		}

		[Test]
		public void TestFromInstructions()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			interpreter.Add("glob is I");
			interpreter.Add("prok is V");
			interpreter.Add("pish is X");
			interpreter.Add("tegj is L");

			interpreter.Add("glob glob Silver is 34 Credits");
			interpreter.Add("glob prok Gold is 57800 Credits");
			interpreter.Add("pish pish Iron is 3910 Credits");

			Assert.AreEqual(
				"pish tegj glob glob is 42",
				interpreter.Add("how much is pish tegj glob glob ?"));
			Assert.AreEqual(
				"glob prok Silver is 68 Credits",
				interpreter.Add("how many Credits is glob prok Silver ?"));
			Assert.AreEqual(
				"glob prok Gold is 57800 Credits",
				interpreter.Add("how many Credits is glob prok Gold ?"));
			Assert.AreEqual(
				"glob prok Iron is 782 Credits",
				interpreter.Add("how many Credits is glob prok Iron ?"));
			Assert.AreEqual(
				"I have no idea what you are talking about",
				interpreter.Add("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
		}

		[Test]
		public void WhenInputIsNullOrEmpty_Throws()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			Assert.Throws<ArgumentNullException>(() => interpreter.Add(null));
			Assert.Throws<ArgumentNullException>(() => interpreter.Add(string.Empty));
			Assert.Throws<ArgumentNullException>(() => interpreter.Add(" "));
		}

		[Test]
		public void QueryForCommodityConversion_ConvertsOneToTheOther()
		{
			var interpreter = IoCInitialization
				.InitiateIoc()
				.Resolve<LanguageInterpreter>();

			interpreter.Add("prok is V");
			interpreter.Add("glob is I");
			interpreter.Add("glob glob Silver is 34 Credits");
			interpreter.Add("glob prok Gold is 57800 Credits");

			Assert.AreEqual(
				"glob Gold is 850 Silver",
				interpreter.Add("how many Silver is glob Gold ?"));
		}

		private static void InitializeSymbols(LanguageInterpreter interpreter)
		{
			interpreter.Add("glob is I");
			interpreter.Add("prok is V");
			interpreter.Add("pish is X");
			interpreter.Add("tegj is L");
		}

		private static void InitializeCommodities(LanguageInterpreter interpreter)
		{
			interpreter.Add("glob glob Silver is 34 Credits");
			interpreter.Add("glob prok Gold is 57800 Credits");
			interpreter.Add("pish pish Iron is 3910 Credits");
		}
	}
}