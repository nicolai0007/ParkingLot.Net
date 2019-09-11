using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace ParkingLot.Netto
{
    public class NettoPriceStrategyTests
    {
        readonly NettoPriceStragegy stragegy = new NettoPriceStragegy();

        [Fact]
        public void simpletest()
        {
            Assert.equal(0, stragegy.CalcalatePrice(TimeSpan.FromMinutes(5)));
        }
    }
}
