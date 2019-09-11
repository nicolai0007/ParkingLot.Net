using System;

namespace ParkingLot.Fotex
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("### Velkommen til Føtex' parkeringsplads ###");
            var parkingLot = new ParkingLot(
                new RealClock(),
                new FotexPriceStrategy());

            var cli = new ParkingLotCLI(parkingLot);

            cli.Run();
        }
    }
}
