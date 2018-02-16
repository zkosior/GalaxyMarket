using System;
using System.Linq;

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

            var components = line.TrimEnd('?', ' ').Split(" is ");
            if (components.Length == 2)
            {
                if (components[0] == "how much")
                {
                    return $"{components[1]} is {this.converter.ToArabic(components[1])}";
                }
                if (components[0] == "how many Credits")
                {
                    var commodity = components[1].Split(" ").Last();
                    if (char.IsUpper(commodity[0]))
                    {
                        var amount = components[1].Replace(commodity, string.Empty).TrimEnd();
                        return $"{amount} {commodity} is {this.market.Query(commodity, amount):0.#} Credits";
                    }
                }
                if (components[0].StartsWith("how many"))
                {
                    var commodity1 = components[0].Split(" ").Last();
                    var commodity2Splitted = components[1].Split(" ");
                    var commodity2Amount = string.Join(" ", commodity2Splitted.SkipLast(1));
                    var commodity2Definition = commodity2Splitted.Last();

                    var commodity1Arabic = this.converter.ToArabic(commodity2Amount);
                    var commodity2Pricet = this.market.Query(commodity2Definition, commodity2Amount);

                    var commodity1UnitPrice = this.market.Query(commodity1, commodity2Amount) / commodity1Arabic;

                    return $"{commodity2Amount} {commodity2Definition} is {commodity2Pricet / commodity1UnitPrice:0.#} {commodity1}";
                }
                var secondPart = components[1].Split(" ");
                if (secondPart.Length == 1)
                {
                    this.definitions.AddDefinition(components[0], components[1]);
                    return null;
                }
                if (secondPart.Length == 2 && secondPart[1] == "Credits")
                {
                    var commodity = components[0].Split(" ").Last();
                    if (char.IsUpper(commodity[0]))
                    {
                        if (int.TryParse(secondPart[0], out var price))
                        {
                            this.market.Add(commodity, components[0].Replace(commodity, string.Empty).Trim(), price);
                            return null;
                        }
                    }
                }
            }
            return "I have no idea what you are talking about";
        }
    }
}