using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Bilka
{
    class BilkaPriceStragegy : IPriceStrategy
    {
        public decimal CalcalatePrice(TimeSpan parkingTime)
        {
            var spans = (decimal)(parkingTime / TimeSpan.FromMinutes(30));
            var spansBegun = Math.Ceiling(spans);
            return 15 * spansBegun;
        }
    }
}
