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
            int firstEmptySpot = GetFirstEmptySpot();

            // There were no empty parking spots.
            if (firstEmptySpot == -1)
            {
                return false;
            }
            // There are duplicate regNrs, return false. 
            if (CheckDuplicateRegNr(vehicle.RegistrationNumber))
            {
                return false;
            }

            // Try to park.

            // I realise i've made TryParkVehicle().
            // That's redundant now I guess.
            garage.ParkVehicle(vehicle, firstEmptySpot);
            return true;
        }
        public List<char[]> GetRegistrationNumbers()
        {
            List<char[]> regNrList = garage.GetRegNrs();
            return regNrList;
        }
        bool CheckDuplicateRegNr(char[] regNr)
        {
            Vehicle[] parkedVehicles = garage.GetVehiclesInGarage();
            for (int i = 0; i < parkedVehicles.Length; i++)
            {
                if (parkedVehicles[i] != null)
                {
                    //if (regNr == parkedVehicles[i].RegistrationNumber)
                    if (regNr.SequenceEqual(parkedVehicles[i].RegistrationNumber))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <returns>Returns index of first empty parking spot. Returns 
        /// -1 if there are no empty spots.</returns>
        int GetFirstEmptySpot()
        {
            Vehicle[] parkedVehicles = garage.GetVehiclesInGarage();
            for (int i = 0; i < parkedVehicles.Length; i++)
            {
                if (parkedVehicles[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool RemoveVehicle(char[] regNr)
        {
            return garage.RemoveVehicle(regNr);
        }

        public void CreateNewGarage(int i)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicles()
        {
            return garage.GetVehiclesInGarage().ToList();
        }

        public Vehicle GetVehicle()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Type, int> GetDictOfVehicles()
        {
            Vehicle[] vehiclesInGarage = garage.GetVehiclesInGarage();

            Dictionary<Type, int> vehicleCounts = new Dictionary<Type, int>();
            try
            {
                for (int i = 0; i < garage.Count(); i++)
                {
                    if (vehiclesInGarage[i] != null) // If Null. Ignore
                    {
                        Type vehicleType = vehiclesInGarage[i].GetType();
                        if (vehicleCounts.ContainsKey(vehicleType))
                        {
                            vehicleCounts[vehicleType]++;
                        }
                        else
                        {
                            vehicleCounts.Add(vehicleType, 1);
                        }
                    }
                }
                return vehicleCounts;
            }
            catch
            {
                throw new Exception();
            }
        }

        public Dictionary<int, Vehicle> GetVehicleByRegNr(string searchQuery)
        {
            Dictionary<int, Vehicle> matchingVehicle = new Dictionary<int, Vehicle>();
            var parkingSpots = garage.GetVehiclesInGarage();
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                var vehicle = parkingSpots[i];
                if (vehicle != null && new string(vehicle.RegistrationNumber) == searchQuery)
                {
                    matchingVehicle.Add(i, vehicle);
                }
            }
            return matchingVehicle;
        }

        public Dictionary<int, Vehicle> GetVehiclesyNrOfWheels(string searchQuery)
        {
            Dictionary<int, Vehicle> matchingVehicles = new Dictionary<int, Vehicle>();
            int nrOfWheelsInQuery;
            if (int.TryParse(searchQuery, out nrOfWheelsInQuery))
            {
                var vehiclesWithIndex = garage.GetVehiclesInGarage()
                    .Select((v, index) => new { Vehicle = v, Index = index })
                    .Where(v => v.Vehicle != null && v.Vehicle.Wheels == nrOfWheelsInQuery);

                foreach (var vehicleWithIndex in vehiclesWithIndex)
                {
                    matchingVehicles.Add(vehicleWithIndex.Index, vehicleWithIndex.Vehicle);
                }
            }
            return matchingVehicles;
        }

        public Dictionary<int, Vehicle> GetVehiclesByPassengerSpots(string searchQuery)
        {
            Dictionary<int, Vehicle> matchingVehicles = new Dictionary<int, Vehicle>();
            throw new NotImplementedException();
        }
        public Dictionary<int, Vehicle> GetVehiclesByColor(string searchQuery)
        {
            Dictionary<int, Vehicle> matchingVehicles = new Dictionary<int, Vehicle>();
            throw new NotImplementedException();
        }
    }
}
