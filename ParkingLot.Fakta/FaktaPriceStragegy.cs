using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Netto
{
    class FaktaPriceStragegy :IPriceStrategy
    {
        public decimal CalcalatePrice(TimeSpan parkingTime)
        {

            var spans = (decimal)((parkingTime - TimeSpan.FromMinutes(5))
                / TimeSpan.FromMinutes(5));
            var spansBegun = Math.Ceiling(spans);

            if (parkingTime < TimeSpan.FromMinutes(5))
            {
                return 0;
            }
            else if(TimeSpan.FromHours(2)>parkingTime)
            {
                var spans = (decimal)((parkingTime - TimeSpan.FromMinutes(5))
    / TimeSpan.FromMinutes(5));

                var spansBegun = Math.Ceiling(spans);
                return spansBegun * 10;
            }
            else
            {
                return spansBegun * 15 + 23*10;
            }
        }
    }
}

    }
}
