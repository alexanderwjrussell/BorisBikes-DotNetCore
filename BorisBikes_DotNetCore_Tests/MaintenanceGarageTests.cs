using BorisBikes_DotNetCore;
using BorisBikes_DotNetCore.Models;
using Xunit;

namespace BorisBikes_DotNetCore_Tests
{
    public class MaintenanceGarageTests
    {
        [Fact]
        public void MaintenanceGarage_RepairBike_ShouldSetBikeWorkingStateToTrue()
        {
            var bike = new Bike();
            var garage = new MaintenanceGarage();
            bike.BreakBike();

            Assert.False(bike.Working);

            garage.RepairBike(bike);

            Assert.True(bike.Working);
        }
    }
}