namespace GalaxyMarket.CurrencyExchange.Handlers
{
	using GalaxyMarket.CurrencyExchange.Converters;

	public class QueryIntergalacticConversion : ILanguageHandler
	{
		private readonly UnitConverter converter;

		public QueryIntergalacticConversion(UnitConverter converter)
		{
			this.converter = converter;
		}

		public bool TryHandle(string input, out string output)
		{
			var amount = ParseInputData(input);
			if (string.IsNullOrWhiteSpace(amount))
			{
				output = string.Empty;
				return false;
			}

			var arabicAmount = this.converter.ToArabic(amount);

			output = $"{amount} is {arabicAmount}";
			return true;
		}

		private static string ParseInputData(string input)
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2 && components[0] == "how much")
			{
				return components[1];
			}

			return null;
		}
	}
}