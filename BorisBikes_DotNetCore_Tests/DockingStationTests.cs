using System;
using BorisBikes_DotNetCore;
using BorisBikes_DotNetCore.Models;
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
        }

        [Fact]
        public void DockingStation_DockBike_ShouldAddABikeToTheBikeStore()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(5);

            dockingStation.DockBike(bike, 0);

            Assert.Equal(dockingStation.BikeStore[0], bike);
        }

        [Fact]
        public void DockingStation_DockBike_ShouldThrowException_WhenThereIsNoSpaceInTheDockingStation()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(0);

            Assert.Throws<Exception>(() => dockingStation.DockBike(bike, 0));
        }

        [Fact]
        public void DockingStation_DockBike_ShouldThrowException_WhennTheBikeIsNotValid()
        {
            var dockingStation = new DockingStation(0);

            Assert.Throws<Exception>(() => dockingStation.DockBike(null, 0));
        }

        [Fact]
        public void DockingStation_DockBike_ShouldThrowException_WhenThereAlreadyABikeParkedInTheLocation()
        {
            var bike1 = new Bike();
            var bike2 = new Bike();
            var dockingStation = new DockingStation(1);
            dockingStation.DockBike(bike1, 0);

            Assert.Throws<Exception>(() => dockingStation.DockBike(bike2, 0));
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
        }

        [Fact]
        public void DockingStation_ReleaseBike_ShouldThrowException_WhenThereTheDockingStationIsEmpty()
        {
            var dockingStation = new DockingStation(0);

            Assert.Throws<Exception>(() => dockingStation.ReleaseBike(0));
        }

        [Fact]
        public void DockingStation_ReleaseBike_ShouldThrowException_WhenThereIsNoBikeInTheLocation()
        {
            var dockingStation = new DockingStation(1);

            Assert.Throws<Exception>(() => dockingStation.ReleaseBike(0));
        }

        [Fact]
        public void DockingStation_ReportBroken_ShouldChangeTheStateOfBikeWorkingToFalse()
        {
            var bike = new Bike();
            var dockingStation = new DockingStation(1);
            dockingStation.DockBike(bike, 0);

            Assert.True(bike.Working);

            dockingStation.ReportBroken(0);

            Assert.False(bike.Working);
        }
    }
}