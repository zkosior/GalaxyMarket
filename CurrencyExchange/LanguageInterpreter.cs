using System;
using System.Linq;

namespace CurrencyExchange
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

            if (!line.EndsWith("?"))
            {
                var components = line.Split(" is ");
                if (components.Length == 2)
                {
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
            }
            else
            {
                var components = line.Split(" is ");
                if (components.Length == 2 && line.EndsWith(" ?"))
                {
                    if (components[0] == "how much")
                    {
                        return $"{components[1].TrimEnd('?', ' ')} is {this.converter.ToArabic(components[1].TrimEnd('?', ' '))}";
                    }
                    var secondPart = components[1].TrimEnd('?', ' ').Split(" ");
                    if (components[0] == "how many Credits" && char.IsUpper(secondPart.Last()[0]))
                    {
                        var commodity = secondPart.Last();
                        var amount = components[1].TrimEnd('?', ' ').Replace(commodity, string.Empty).TrimEnd();
                        return $"{amount} {commodity} is {this.market.Query(commodity, components[1].TrimEnd('?', ' ').Replace(commodity, string.Empty).TrimEnd()):0.#} Credits";
                    }
                }
            }
            return "I have no idea what you are talking about";
        }
    }
}