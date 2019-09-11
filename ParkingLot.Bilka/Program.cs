using System;

namespace ParkingLot.Bilka
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("### Velkommen til Bilkas parkeringsplads ###");
            var parkingLot = new ParkingLot(new RealClock(), null);

            var cli = new ParkingLotCLI(parkingLot);

            cli.Run();
        }
    }
}
