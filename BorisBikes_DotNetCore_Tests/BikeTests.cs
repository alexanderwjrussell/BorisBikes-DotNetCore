using System;
using BorisBikes_DotNetCore.Models;
using Xunit;

namespace BorisBikes_DotNetCore_Tests
{
    public class BikeTests
    {
        [Fact]
        public void Bike_ShouldHaveInitialState_WhenNew()
        {
            var bike = new Bike();
            
            Assert.True(bike.Working);
            Assert.Equal(0, bike.CurrentMilage);
            Assert.IsType<Guid>(bike.Id);
        }
        
        [Fact]
        public void Bike_ShouldHaveWorkingFalse_WhenBreakBikeIsCalled()
        {
            var bike = new Bike();
            
            bike.BreakBike();
            
            Assert.False(bike.Working);
        }
        
        [Fact]
        public void Bike_ShouldHaveWorkingTrue_WhenFixBikeIsCalledOnBrokenBike()
        {
            var bike = new Bike();
            
            bike.BreakBike();
            
            Assert.False(bike.Working);
            
            bike.FixBike();
            
            Assert.True(bike.Working);
        }
        
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Bike_ShouldAddMileage_WhenAddMileageIsCalled(int milage)
        {
            var bike = new Bike();
            
            bike.AddMileage(milage);
            
            Assert.Equal(milage, bike.CurrentMilage);
        }
    }
}