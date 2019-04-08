namespace GalaxyMarket.CurrencyExchange
{
	using GalaxyMarket.CurrencyExchange.Handlers;
	using System;
	using System.Collections.Generic;

	public class LanguageInterpreter
	{
		private readonly IEnumerable<ILanguageHandler> handlers;

		public LanguageInterpreter(IEnumerable<ILanguageHandler> handlers)
		{
			this.handlers = handlers;
		}

		public string Add(string line)
		{
			ValidateInput(line);

			foreach (var handler in this.handlers)
			{
				if (handler.TryHandle(line, out var output))
				{
					return output;
				}
			}

			return "I have no idea what you are talking about";
		}

		private static void ValidateInput(string line)
		{
			if (string.IsNullOrWhiteSpace(line))
				throw new ArgumentNullException($"{nameof(line)}");
		}
	}
}