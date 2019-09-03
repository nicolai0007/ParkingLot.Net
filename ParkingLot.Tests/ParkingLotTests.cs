using System;
using Xunit;

namespace ParkingLot.Tests
{
    public class ParkingLotTests
    {
        readonly IParkingLot lot;

        public ParkingLotTests()
        {
            lot = new ParkingLot();
            Gates.Reset();
        }

        [Fact]
        public void CanCheckin()
        {
            lot.Checkin("AB 12 123");
            Assert.Equal(1, Gates.NumberOfCars);
        }

        [Fact]
        public void CanCheckTwoCarsIn()
        {
            lot.Checkin("AB 12 123");
            lot.Checkin("AB 12 124");
            Assert.Equal(2, Gates.NumberOfCars);
        }

        [Fact]
        public void CannotCheckinTwice()
        {
            lot.Checkin("AB 12 123");

            Assert.Throws<InvalidOperationException>(() => lot.Checkin("AB 12 123"));
            Assert.Equal(1, Gates.NumberOfCars);
        }

        [Fact]
        public void CanBeginCheckout()
        {
            lot.Checkin("AB 12 123");

            lot.BeginCheckout("AB 12 123");
        }

        [Fact]
        public void CannotBeginCheckoutTwice()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            Assert.Throws<InvalidOperationException>(() => lot.BeginCheckout("AB 12 123"));
        }

        [Fact]
        public void CannotBeginCheckoutIfNotParked()
        {
            Assert.Throws<InvalidOperationException>(() => lot.BeginCheckout("AB 12 123"));
        }

        [Fact]
        public void OwesNothingWhenNotCheckedIn()
        {
            Assert.Equal(0, lot.GetRemainingFee("AB 12 123"));
        }

        [Fact]
        public void Owes40WhenBeginingCheckingOut()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            Assert.Equal(40m, lot.GetRemainingFee("AB 12 123"));
        }

        [Fact]
        public void Owes10WhenPaid30()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            lot.Pay("AB 12 123", 30m);

            Assert.Equal(10m, lot.GetRemainingFee("AB 12 123"));
        }

        [Fact]
        public void CannotLeaveWithoutPaying()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            Assert.Throws<InvalidOperationException>(() => lot.Leave("AB 12 123"));
        }

        [Fact]
        public void CannotLeaveWithoutPayingFullFee()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            lot.Pay("AB 12 123", 30m);

            Assert.Throws<InvalidOperationException>(() => lot.Leave("AB 12 123"));
        }

        [Fact]
        public void CanLeaveWhenFeeIsPayed()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            lot.Pay("AB 12 123", 40m);

            lot.Leave("AB 12 123");

            Assert.Equal(0, Gates.NumberOfCars);
        }


        [Fact]
        public void CanLeaveWhenMoreThanFeeIsPayed()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            lot.Pay("AB 12 123", 20m);
            lot.Pay("AB 12 123", 50m);

            Assert.Equal(-30m, lot.GetRemainingFee("AB 12 123"));
            lot.Leave("AB 12 123");

            Assert.Equal(0, Gates.NumberOfCars);
        }


        [Fact]
        public void CannotPayWhenNotCheckedIn()
        {
            Assert.Throws<InvalidOperationException>(() => lot.Pay("AB 12 123", 10));
        }

        [Fact]
        public void CannotPayNegativeAmount()
        {
            lot.Checkin("AB 12 123");
            lot.BeginCheckout("AB 12 123");

            Assert.Throws<InvalidOperationException>(() => lot.Pay("AB 12 123", -10));
        }

        [Fact]
        public void CannotLeaveIfNotCheckedIn()
        {
            Assert.Throws<InvalidOperationException>(() => lot.Leave("AB 123"));
        }
    }
}
