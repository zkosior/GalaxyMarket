using System.Linq;

namespace ZKosior.ThoughtWotks.GalaxyMarket.CurrencyExchange
{
    public class QueryComodityConversion : ILanguageHandler
    {
        private UnitConverter Converter { get; }

        private CommonMarket Market { get; }

        public QueryComodityConversion(UnitConverter converter, CommonMarket market)
        {
            this.Converter = converter;
            this.Market = market;
        }

        public bool TryHandle(string input, out string output)
        {
            var components = input.TrimEnd('?', ' ').Split(" is ");
            if (components.Length == 2 && components[0].StartsWith("how many"))
            {
                var commodity1 = components[0].Split(" ").Last();
                var commodity2Splitted = components[1].Split(" ");
                var commodity2Amount = string.Join(" ", commodity2Splitted.SkipLast(1));
                var commodity2Definition = commodity2Splitted.Last();

                var commodity1Arabic = this.Converter.ToArabic(commodity2Amount);
                var commodity2Pricet = this.Market.Query(commodity2Definition, commodity2Amount);

                var commodity1UnitPrice = this.Market.Query(commodity1, commodity2Amount) / commodity1Arabic;

                output = $"{commodity2Amount} {commodity2Definition} is {commodity2Pricet / commodity1UnitPrice:0.#} {commodity1}";
                return true;
            }

            output = string.Empty;
            return false;
        }
    }
}