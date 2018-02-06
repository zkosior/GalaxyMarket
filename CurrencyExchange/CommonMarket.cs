using System.Collections.Generic;

namespace CurrencyExchange
{
    public class CommonMarket
    {
        private readonly Dictionary<string, decimal> commodities = new Dictionary<string, decimal>();
        private readonly UnitConverter unitConverter;

        public CommonMarket(UnitConverter unitConverter)
        {
            this.unitConverter = unitConverter;
        }

        public void Add(string commodity, string amount, decimal price)
        {
            commodities.Add(commodity, price / this.unitConverter.ToArabic(amount));
        }

        public decimal Query(string commodity, string amount)
        {
            return this.commodities[commodity] * this.unitConverter.ToArabic(amount);
        }
    }
}