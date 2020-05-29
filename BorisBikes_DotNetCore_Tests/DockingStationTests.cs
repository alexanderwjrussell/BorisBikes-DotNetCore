using System;
using BorisBikes_DotNetCore;
using BorisBikes_DotNetCore.Models;
using FluentAssertions;
using Xunit;

namespace BorisBikes_DotNetCore_Tests
{
    public class DockingStationTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(100)]
        public void DockingStation_ShouldInitialiseWithBikeStoreWithSetCapactiy(int capacity)
        {
            var dockingStation = new DockingStation(capacity);

            Assert.Equal(capacity, dockingStation.BikeStore.Length);

            dockingStation.BikeStore.Length.Should().Equals(capacity);
        }

        [Fact]
        public void DockingStation_DockBike_ShouldAddABikeToTheBikeStore()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(5);

            dockingStation.DockBike(bike, 0);

            Assert.Equal(dockingStation.BikeStore[0], bike);

            dockingStation.BikeStore[0].Should().Equals(bike);
        }

        [Fact]
        public void DockingStation_DockBike_ShouldThrowException_WhenThereIsNoSpaceInTheDockingStation()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(0);

            Assert.Throws<Exception>(() => dockingStation.DockBike(bike, 0));

            Action action = () => dockingStation.DockBike(bike, 0);
            action.Should().Throw<Exception>().WithMessage("No space exists");
        }

        [Fact]
        public void DockingStation_DockBike_ShouldThrowException_WhennTheBikeIsNotValid()
        {
            var dockingStation = new DockingStation(1);

            Assert.Throws<Exception>(() => dockingStation.DockBike(null, 0));

            Action action = () => dockingStation.DockBike(null, 0);
            action.Should().Throw<Exception>().WithMessage("Null is not a valid bike");
        }

        [Fact]
        public void DockingStation_DockBike_ShouldThrowException_WhenThereAlreadyABikeParkedInTheLocation()
        {
            var bike1 = new Bike();
            var bike2 = new Bike();
            var dockingStation = new DockingStation(1);
            dockingStation.DockBike(bike1, 0);

            Assert.Throws<Exception>(() => dockingStation.DockBike(bike2, 0));

            Action action = () => dockingStation.DockBike(bike2, 0);
            action.Should().Throw<Exception>().WithMessage("Space is taken. MUPPET!");
        }

        [Fact]
        public void DockingStation_ReleaseBike_ShouldRemoveABikeToTheBikeStore()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(5);
            dockingStation.DockBike(bike, 0);

            Assert.Equal(dockingStation.BikeStore[0], bike);

            var acquiredBike = dockingStation.ReleaseBike(0);

            Assert.Null(dockingStation.BikeStore[0]);
            Assert.Equal(bike, acquiredBike);

            dockingStation.BikeStore[0].Should().Equals(null);
            bike.Should().Equals(acquiredBike);
        }

        [Fact]
        public void DockingStation_ReleaseBike_ShouldThrowException_WhenThereTheDockingStationIsEmpty()
        {
            var dockingStation = new DockingStation(0);

            Assert.Throws<Exception>(() => dockingStation.ReleaseBike(0));

            Action action = () => dockingStation.ReleaseBike(0);
            action.Should().Throw<Exception>().WithMessage("Station is empty");
        }

        [Fact]
        public void DockingStation_ReleaseBike_ShouldThrowException_WhenThereIsNoBikeInTheLocation()
        {
            var dockingStation = new DockingStation(1);

            Assert.Throws<Exception>(() => dockingStation.ReleaseBike(0));

            Action action = () => dockingStation.ReleaseBike(0);
            action.Should().Throw<Exception>().WithMessage("Enjoy your AirBike Ride!");
        }

        [Fact]
        public void DockingStation_ReportBroken_ShouldChangeTheStateOfBikeWorkingToFalse()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(1);
            dockingStation.DockBike(bike, 0);

            Assert.True(bike.Working);

            bike.Working.Should().Equals(true);

            dockingStation.ReportBroken(0);

            Assert.False(bike.Working);

            bike.Working.Should().Equals(false);
        }
    }
}