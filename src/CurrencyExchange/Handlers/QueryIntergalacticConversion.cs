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
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2 && components[0] == "how much")
			{
				output = $"{components[1]} is {this.converter.ToArabic(components[1])}";
				return true;
			}

			output = string.Empty;
			return false;
		}
	}
}