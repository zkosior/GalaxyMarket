namespace GalaxyMarket.CurrencyExchange
{
	using DryIoc;
	using GalaxyMarket.CurrencyExchange;

	public static class IoCInitialization
	{
		public static Container InitiateIoc()
		{
			var container = new Container(rules => rules.WithTrackingDisposableTransients());
			RegisterDependencies(container);
			return container;
		}

		private static void RegisterDependencies(Container container)
		{
			container.Register<LanguageInterpreter>();
			container.Register<CommonMarket>(Reuse.Singleton);
			container.Register<UnitConverter>();
			container.Register<SymbolDefinition>(Reuse.Singleton);

			container.Register<ILanguageHandler, QueryIntergalacticConversion>();
			container.Register<ILanguageHandler, QueryCommodityPrice>();
			container.Register<ILanguageHandler, QueryComodityConversion>();
			container.Register<ILanguageHandler, DeclareIntergalacticUnits>();
			container.Register<ILanguageHandler, DeclareCommoditiesPriceInCredits>();
		}
	}
}