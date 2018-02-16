using DryIoc;
using ZKosior.ThoughtWotks.GalaxyMarket.CurrencyExchange;

namespace ZKosior.ThoughtWorks.GalaxyMarket.CurrencyExchange
{
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
            container.Register<CommonMarket>();
            container.Register<UnitConverter>();
            container.Register<SymbolDefinition>(Reuse.Singleton);
        }
    }
}