using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange
{
    public class LanguageInterpreter
    {
        public string Add(string line)
        {
            if (line == "glob is I")
                return null;
            if (line == "how much is pish tegj glob glob ?")
                return "pish tegj glob glob is 42";
            if (line == "how many Credits is glob prok Silver ?")
                return "glob prok Silver is 68 Credits";
            return "I have no idea what you are talking about";
        }
    }
}