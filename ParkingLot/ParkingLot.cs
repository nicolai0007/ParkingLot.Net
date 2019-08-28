using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot : IParkingLot
    {
        private List<string> checkedInCars = new List<string>();

        public void BeginCheckout(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public void Checkin(string licensePlate)
        {
            if (checkedInCars.Contains(licensePlate))
            {
                Error("Car already checked in");
            }
            checkedInCars.Add(licensePlate);
            Gates.OpenEntranceGate();
        }

        public decimal GetRemainingFee(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public void Leave(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public void Pay(string licensePlate, decimal amount)
        {
            throw new NotImplementedException();
        }

        void Error(string msg)
        {
            throw new InvalidOperationException(msg);
        }
    }
}
