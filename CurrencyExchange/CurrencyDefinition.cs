using System;
using System.Collections.Generic;

namespace CurrencyExchange
{
    public class CurrencyDefinition
    {
        private readonly Dictionary<string, Roman> definitions = new Dictionary<string, Roman>();
        private readonly List<Roman> whitelistedNumerals = new List<Roman> { Roman.I, Roman.V, Roman.X, Roman.L, Roman.C, Roman.D, Roman.M };

        public void AddDefinition(string unit, Roman definition)
        {
            if (!this.whitelistedNumerals.Contains(definition))
            {
                throw new AggregateException($"Not supported Roman Numeral: {definition}");
            }

            if (this.definitions.ContainsKey(unit))
            {
                throw new AggregateException($"Intergalactic unit already registered: {unit}");
            }

            if (this.definitions.ContainsValue(definition))
            {
                throw new AggregateException($"Roman numeral already registered: {definition}");
            }

            this.definitions.Add(unit, definition);
        }

        public Roman this[string key] => this.definitions.ContainsKey(key)
            ? this.definitions[key]
            : throw new AggregateException($"Intergalactic unit not registered: {key}");

        public bool Contains(string unit)
        {
            return this.definitions.ContainsKey(unit);
        }
    }
}