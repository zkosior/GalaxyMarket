using System;

namespace ZKosior.ThoughtWotks.GalaxyMarket.CurrencyExchange
{
    public class LanguageInterpreter
    {
        private SymbolDefinition Definitions { get; }

        private UnitConverter Converter { get; }

        private CommonMarket Market { get; }

        public LanguageInterpreter(SymbolDefinition definitions, UnitConverter converter, CommonMarket market)
        {
            this.Definitions = definitions;
            this.Converter = converter;
            this.Market = market;
        }

        public string Add(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentNullException($"{nameof(line)}");

            if (new QueryIntergalacticConversion(this.Converter).TryHandle(line, out var output) ||
                new QueryCommodityPrice(this.Market).TryHandle(line, out output) ||
                new QueryComodityConversion(this.Converter, this.Market).TryHandle(line, out output) ||
                new DeclareIntergalacticUnits(this.Definitions).TryHandle(line, out output) ||
                new DeclareCommoditiesPriceInCredits(this.Market).TryHandle(line, out output))
            {
                return output;
            }

            return "I have no idea what you are talking about";
        }
    }
}