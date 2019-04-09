namespace GalaxyMarket.CurrencyExchange.Handlers
{
	using GalaxyMarket.CurrencyExchange.Market;

	public class DeclareIntergalacticUnits : ILanguageHandler
	{
		private readonly SymbolDefinition definitions;

		public DeclareIntergalacticUnits(SymbolDefinition definitions)
		{
			this.definitions = definitions;
		}

		public bool TryHandle(string input, out string output)
		{
			output = null;
			(string intergalacticNumber, string romanNumber) = ParseInputData(input);
			if (string.IsNullOrWhiteSpace(intergalacticNumber) ||
				string.IsNullOrWhiteSpace(romanNumber))
			{
				return false;
			}

			this.definitions.AddDefinition(intergalacticNumber, romanNumber);

			return true;
		}

#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly

		private static (string intergalacticNumber, string romanNumber) ParseInputData(string input)
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2)
			{
				var secondPart = components[1].Split(" ");
				if (secondPart.Length == 1)
				{
					return (components[0], components[1]);
				}
			}

			return (null, null);
		}
	}
}