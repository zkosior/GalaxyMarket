namespace GalaxyMarket.CurrencyExchange
{
	public interface ILanguageHandler
	{
		bool TryHandle(string input, out string output);
	}
}