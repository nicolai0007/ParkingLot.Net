using System;
using System.Linq;

namespace ParkingLot.Fotex
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("### Velkommen til Føtex' parkeringsplads ###");
            var parkingLot = new ParkingLot(
                new RealClock(), 15, TimeSpan.FromMinutes(15), TimeSpan.Zero);

            var cli = new ParkingLotCLI(parkingLot);

            cli.Run();
        }
    }
}
