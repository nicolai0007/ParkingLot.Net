using System;

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

        public string Command(string cmd, params string[] @params)
        {
            var debt = 0m;
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
                        msg += " og kan forlade pladsen.";
                    }
                    else if (debt < 0)
                    {
                        msg += $" og kan forlade pladsen. Byttepenge: {-debt} DKK.";
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
                    return "What!?";
            }
        }
    }
}
