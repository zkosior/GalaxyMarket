using System;

namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        private readonly CurrencyDefinition definitions;

        public CurrencyConverter(CurrencyDefinition definitions)
        {
            this.definitions = definitions;
        }

        public string Convert(string unit)
        {
            if (!this.definitions.Contains(unit))
            {
                throw new AggregateException();
            }

            return this.definitions[unit].ToString();
        }
    }
}