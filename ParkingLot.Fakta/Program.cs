using System;

namespace ParkingLot.Fakta
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("### Velkommen til Faktas parkeringsplads ###");
            var parkingLot = new ParkingLot(new RealClock(), null);

            var cli = new ParkingLotCLI(parkingLot);

            cli.Run();
        }
    }
}
