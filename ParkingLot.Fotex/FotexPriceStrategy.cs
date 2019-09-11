using System;
namespace ParkingLot.Fotex
{
    public class FotexPriceStrategy : IPriceStrategy
    {
        public decimal CalcalatePrice(TimeSpan parkingTime)
        {
            var spans = (decimal)(parkingTime / TimeSpan.FromMinutes(15));
            var spansBegun = Math.Ceiling(spans);
            return 15 * spansBegun;
        }
    }
}
