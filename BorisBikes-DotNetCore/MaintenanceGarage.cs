using BorisBikes_DotNetCore.Models;

namespace BorisBikes_DotNetCore
{
    public class MaintenanceGarage
    {
        public void RepairBike(Bike bike)
        {
            bike.Working = true;
        }
    }
}