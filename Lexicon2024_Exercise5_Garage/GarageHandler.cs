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
            Garage<Vehicle> garage = new Garage<Vehicle>(parkingSpots);
        }
        public bool ParkVehicle(Vehicle vehicle)
        {
            bool parkedFlag = false;
            foreach (Vehicle parkedVehicle in garage)
            {
                if (parkedVehicle.RegistrationNumber == vehicle.RegistrationNumber)
                {
                    return false;
                }
                else
                {
                    parkedFlag = true;
                }
            }
            garage.Append(vehicle);
            return parkedFlag;



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
            Dictionary<Type, int> vehicleCounts = new Dictionary<Type, int>();
            try
            {
                foreach (var vehicle in garage)
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
