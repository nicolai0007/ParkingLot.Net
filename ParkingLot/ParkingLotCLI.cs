using System;
using System.Linq;

namespace ParkingLot
{
    public class ParkingLotCLI
    {
        readonly IParkingLot parkingLot;

        public ParkingLotCLI(IParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public bool Exit { get; private set; }

        public void Run()
        {
            while (!Exit)
            {
                Console.Write(": ");
                var input = Console.ReadLine().Split(" ");

                try
                {
                    var output = Command(input[0], input.Skip(1).ToArray());
                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        Console.Write("! ");
                        Console.WriteLine(output);
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!!!!!!!!!!!!!!!!!");
                    Console.Error.WriteLine(e.Message);
                    Console.Error.WriteLine("!!!!!!!!!!!!!!!!!!");
                }
            }
        }

        string Command(string cmd, params string[] @params)
        {
            decimal debt;
            switch (cmd)
            {
                case ">":
                    parkingLot.Checkin(@params[0]);
                    return $"Velkommen '{@params[0]}'.";
                case "<":
                    parkingLot.BeginCheckout(@params[0]);
                    debt = parkingLot.GetRemainingFee(@params[0]);
                    return $"'{@params[0]}' er ved at forlade pladsen og skylder {debt}.";
                case "$":
                    var amount = decimal.Parse(@params[1]);
                    parkingLot.Pay(@params[0], amount);
                    debt = parkingLot.GetRemainingFee(@params[0]);

                    var msg = $"'{@params[0]}' betalte {amount} DKK";

                    if (debt == 0)
                    {
                        msg += " og forlader pladsen.";
                        parkingLot.Leave(@params[0]);
                    }
                    else if (debt < 0)
                    {
                        msg += $" og forlader pladsen. Byttepenge: {-debt} DKK.";
                        parkingLot.Leave(@params[0]);
                    }
                    else
                    {
                        msg += $" og skylder {debt} DKK";
                    }
                    return msg;
                case "exit":
                    Exit = true;
                    return null;
                default:
                    return "WTF? Does this help: \n" +
                        "> plate          : checkin a car\n" +
                        "< plate          : begin checking out a car\n" +
                        "$ plate amount   : pay and try to leave\n" +
                        "exit             : exits the program";
            }
        }
    }
}
