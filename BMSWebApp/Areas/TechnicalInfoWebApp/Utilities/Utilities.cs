using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalInfoWebApp.Utilities
{
    public static class Utilities
    {
        public static decimal NumberToDecimal(this short? number)
        {
            if (number == 0 || number == null)
            {
                return 0;
            }

            string result = "0.";

            for (int i = 0; i < number; i++)
            {
                result = result + "0";
            }

            result = result + "1";

            return decimal.Parse(result);
        }
    }
}
