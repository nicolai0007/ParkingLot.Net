using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Netto
{
    class NettoPriceStragegy : IPriceStrategy
    {
        public decimal CalcalatePrice(TimeSpan parkingTime)
        {
            var spans = (decimal)((parkingTime - TimeSpan.FromMinutes(30)) 
                / TimeSpan.FromMinutes(15));
            var spansBegun = Math.Ceiling(spans);

            if (spansBegun<0)
            {
                return 0;
            }
            else
            {
                return spansBegun * 15;
            }
        }
    }
}
