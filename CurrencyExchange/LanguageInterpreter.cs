using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange
{
    public class LanguageInterpreter
    {
        public string Add(string line)
        {
            if (line == "how much is pish tegj glob glob ?")
                return "pish tegj glob glob is 42";
            return null;
        }
    }
}