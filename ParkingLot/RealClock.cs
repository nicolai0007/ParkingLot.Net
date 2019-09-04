using System;
namespace ParkingLot
{
    public class RealClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
