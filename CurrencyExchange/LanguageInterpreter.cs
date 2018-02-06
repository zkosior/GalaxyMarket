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