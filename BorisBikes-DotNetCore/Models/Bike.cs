using System;

namespace BorisBikes_DotNetCore.Models
{
    public class Bike
    {
        public bool Working { get; set; }
        public Guid Id { get; set; }
        public int CurrentMilage { get; set; }

        public Bike()
        {
            Working = true;
            Id = Guid.NewGuid();
            CurrentMilage = 0;
        }

        public void BreakBike()
        {
            Working = false;
        }

        public void FixBike()
        {
            Working = true;
        }

        public void AddMileage(int milesAdded)
        {
            CurrentMilage += milesAdded;
        }
    }
}