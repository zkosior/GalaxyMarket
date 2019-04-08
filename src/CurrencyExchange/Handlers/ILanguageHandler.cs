namespace GalaxyMarket.CurrencyExchange.Handlers
{
	public interface ILanguageHandler
	{
		bool TryHandle(string input, out string output);
	}
}