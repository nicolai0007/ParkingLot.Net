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

            while (!cli.Exit)
            {
                Console.Write(": ");
                var input = Console.ReadLine().Split(" ");

                var output = cli.Command(input[0], input.Skip(1).ToArray());
                if (!string.IsNullOrWhiteSpace(output))
                {
                    Console.Write("! ");
                    Console.WriteLine(output);
                    Console.WriteLine();
                }
            }
        }
    }
}
