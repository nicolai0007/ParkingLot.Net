using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot : IParkingLot
    {
        readonly List<string> checkedInCars = new List<string>();
        readonly Dictionary<string, decimal> debt = new Dictionary<string, decimal>();

        public void Checkin(string licensePlate)
        {
            if (checkedInCars.Contains(licensePlate))
            {
                Error("Car already checked in");
            }
            checkedInCars.Add(licensePlate);
            Gates.OpenEntranceGate();
        }

        public void BeginCheckout(string licensePlate)
        {
            if (checkedInCars.Contains(licensePlate))
            {
                debt.Add(licensePlate, 40);
                checkedInCars.Remove(licensePlate);
            }
            else
            {
                Error("Car not checkedIn");
            }
        }

        public decimal GetRemainingFee(string licensePlate)
        {
            return debt.GetValueOrDefault(licensePlate, 0);
        }

        public void Pay(string licensePlate, decimal amount)
        {
            if (debt.ContainsKey(licensePlate))
            {
                if (amount >= 0)
                {
                    debt[licensePlate] -= amount;
                }
                else
                {
                    Error("You did not pay!");
                }
            }
            else
            {
                Error("Something went wrong");
            }
        }

        public void Leave(string licensePlate)
        {
            if (debt.ContainsKey(licensePlate) && debt[licensePlate] <= 0)
            {
                debt.Remove(licensePlate);
                checkedInCars.Remove(licensePlate);
                Gates.OpenExitGate();
            }
            else
            {
                Error("Please pay!");
            }
        }

        void Error(string msg)
        {
            throw new InvalidOperationException(msg);
        }
    }
}
