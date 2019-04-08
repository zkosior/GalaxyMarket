namespace GalaxyMarket.CurrencyExchange
{
	public class QueryIntergalacticConversion : ILanguageHandler
	{
		public QueryIntergalacticConversion(UnitConverter converter)
		{
			this.Converter = converter;
		}

		private UnitConverter Converter { get; }

		public bool TryHandle(string input, out string output)
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2 && components[0] == "how much")
			{
				output = $"{components[1]} is {this.Converter.ToArabic(components[1])}";
				return true;
			}

			output = string.Empty;
			return false;
		}
	}
}