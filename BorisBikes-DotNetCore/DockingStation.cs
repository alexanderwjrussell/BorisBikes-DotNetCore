using System;
using BorisBikes_DotNetCore.Models;

namespace BorisBikes_DotNetCore
{
    public class DockingStation
    {
        public Bike[] BikeStore { get; private set; }

        public DockingStation(int capacity)
        {
            BikeStore = new Bike[capacity];
        }

        public void DockBike(Bike bike, int location)
        {
            if ((location) >= BikeStore.Length)
                throw new Exception("No space exists");

            if (bike == null)
                throw new Exception("Null is not a valid bike");

            if (BikeStore[location] != null)
                throw new Exception("Space is taken. MUPPET!");

            BikeStore[location] = bike;
        }

        public Bike ReleaseBike(int location)
        {
            if (BikeStore.Length == 0)
                throw new Exception("Station is empty");
            
            if (BikeStore[location] == null)
                throw new Exception("Enjoy your AirBike Ride!");

            var bike = BikeStore[location];

            BikeStore[location] = null;

            return bike;
        }

        public void ReportBroken(int location)
        {
            var bike = BikeStore[location];
            bike.BreakBike();
        }
    }
}