using Lexicon2024_Exercise5_Garage.Vehicles;
using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage
{
    //internal class GarageHandler : IGarageHandler
    internal class GarageHandler : IGarageHandler
    {
        Garage<Vehicle> garage;
        public GarageHandler(int parkingSpots)
        {
            garage = new Garage<Vehicle>(parkingSpots);
        }
        public bool TryParkVehicle(Vehicle vehicle)
        {
            return garage.TryParkVehicle(vehicle);


            // We need to send this back to the Manager > UI somehow...?
            // Ask what Vehicle type with list menu options.

            // Registration Number, 6 chars 
            // Check all other vehicles RegistrationNumbers

            throw new NotImplementedException();
        }
        public bool RemoveVehicle()
        {
            throw new NotImplementedException();
        }

        public void CreateNewGarage(int i)
        {
            throw new NotImplementedException();
        }
        public Dictionary<Type, int> VehiclesInGarage()
        {
            Vehicle[] vehiclesInGarage = garage.GetVehiclesInGarage();

            Dictionary<Type, int> vehicleCounts = new Dictionary<Type, int>();
            try
            {
                for (int i = 0; i < garage.Count(); i++)
                {
                    Type vehicleType = vehicle.GetType();
                    if (vehicleCounts.ContainsKey(vehicleType))
                    {
                        vehicleCounts[vehicleType]++;
                    }
                    else
                    {
                        vehicleCounts.Add(vehicleType, 1);
                    }
                }
                return vehicleCounts;
            }
            catch
            {
                return vehicleCounts;
            }
        }
    }
}
