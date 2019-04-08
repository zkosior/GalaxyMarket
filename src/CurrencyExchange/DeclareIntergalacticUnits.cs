namespace GalaxyMarket.CurrencyExchange
{
	public class DeclareIntergalacticUnits : ILanguageHandler
	{
		public DeclareIntergalacticUnits(SymbolDefinition definitions)
		{
			this.Definitions = definitions;
		}

		private SymbolDefinition Definitions { get; }

		public bool TryHandle(string input, out string output)
		{
			var components = input.TrimEnd('?', ' ').Split(" is ");
			if (components.Length == 2)
			{
				var secondPart = components[1].Split(" ");
				if (secondPart.Length == 1)
				{
					this.Definitions.AddDefinition(components[0], components[1]);
					output = null;
					return true;
				}
			}

			output = null;
			return false;
		}
	}
}