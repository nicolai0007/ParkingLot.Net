using System;

namespace ParkingLot.Netto
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("### Velkommen til Nettos parkeringsplads ###");
            var parkingLot = new ParkingLot(new RealClock(), null);

            var cli = new ParkingLotCLI(parkingLot);

            cli.Run();
        }
    }
}
