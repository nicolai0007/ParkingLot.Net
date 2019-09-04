using System;
namespace ParkingLot.Tests
{
    public class TestClock : IClock
    {
        DateTime time;

        public DateTime Now()
        {
            return time;
        }

        public void Forward(TimeSpan span)
        {
            time += span;
        }
    }
}
