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
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2)
			{
				var secondPart = components[1].Split(" ");
				if (secondPart.Length == 1)
				{
					this.definitions.AddDefinition(components[0], components[1]);
					output = null;
					return true;
				}
			}

			output = null;
			return false;
		}
	}
}