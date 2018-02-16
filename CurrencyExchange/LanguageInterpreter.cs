using System;

namespace ZKosior.ThoughtWotks.GalaxyMarket.CurrencyExchange
{
    public class LanguageInterpreter
    {
        private readonly SymbolDefinition definitions = new SymbolDefinition();
        private readonly UnitConverter converter;
        private readonly CommonMarket market;

        public LanguageInterpreter()
        {
            this.converter = new UnitConverter(definitions);
            this.market = new CommonMarket(converter);
        }

        public string Add(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentNullException($"{nameof(line)}");

            if (new QueryIntergalacticConversion(this.converter).TryHandle(line, out var output) ||
                new QueryCommodityPrice(this.market).TryHandle(line, out output) ||
                new QueryComodityConversion(this.converter, this.market).TryHandle(line, out output) ||
                new DeclareIntergalacticUnits(this.definitions).TryHandle(line, out output) ||
                new DeclareCommoditiesPriceInCredits(this.market).TryHandle(line, out output))
            {
                return output;
            }

            return "I have no idea what you are talking about";
        }
    }
}