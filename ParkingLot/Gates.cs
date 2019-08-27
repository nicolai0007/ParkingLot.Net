using System;
using System.Diagnostics.Tracing;
using System.Threading;

namespace ParkingLot
{
    public static class Gates
    {
        public static int NumberOfCars { get; private set; }

        public static void OpenEntranceGate()
        {
            NumberOfCars++;
        }

        public static void OpenExitGate()
        {
            NumberOfCars--;
        }

        public static void Reset()
        {
            NumberOfCars = 0;
        }
    }
}
