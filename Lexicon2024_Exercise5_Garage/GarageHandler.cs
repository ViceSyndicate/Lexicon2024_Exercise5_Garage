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
        public char[] GetRegistrationNumbers()
        {
            char[] regNrList = garage.GetRegNrs();
            return regNrList;
        }
        bool CheckDuplicateRegNr(char[] regNr)
        {
            Vehicle[] parkedVehicles = garage.GetVehiclesInGarage();
            for (int i = 0; i < parkedVehicles.Length; i++)
            {
                if (parkedVehicles[i] != null)
                {
                    if (regNr == parkedVehicles[i].RegistrationNumber)
                    {
                        return true; // Could extend to give an error message of some sort...
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
    }
}
