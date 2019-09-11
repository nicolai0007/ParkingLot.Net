using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot : IParkingLot
    {
        readonly Dictionary<string, DateTime> checkedInCars = new Dictionary<string, DateTime>();
        readonly Dictionary<string, decimal> debt = new Dictionary<string, decimal>();
        readonly IClock clock;
        readonly IPriceStrategy priceStrategy;

        public ParkingLot(IClock clock, IPriceStrategy priceStrategy)
        {
            this.clock = clock;
            this.priceStrategy = priceStrategy;
        }

        public void Checkin(string licensePlate)
        {
            if (checkedInCars.ContainsKey(licensePlate))
            {
                Error("Car already checked in");
            }
            checkedInCars.Add(licensePlate, clock.Now());
            Gates.OpenEntranceGate();
        }

        public void BeginCheckout(string licensePlate)
        {
            if (checkedInCars.ContainsKey(licensePlate))
            {
                var checkinTime = checkedInCars[licensePlate];
                var checkoutTime = clock.Now();

                var time = checkoutTime - checkinTime;
                debt.Add(licensePlate, priceStrategy.CalcalatePrice(time));

                //var payedTime = time - freeTime;

                //if (payedTime < TimeSpan.Zero)
                //{
                //    debt.Add(licensePlate, 0);
                //}
                //else
                //{
                //    var spans = (decimal)(payedTime / span);
                //    var spansBegun = Math.Ceiling(spans);

                //    debt.Add(licensePlate, spansBegun * price);
                //}
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
