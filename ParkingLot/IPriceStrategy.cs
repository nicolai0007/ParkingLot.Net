using System;
namespace ParkingLot
{
    public interface IPriceStrategy
    {
        decimal CalcalatePrice(TimeSpan parkingTime);
    }
}
