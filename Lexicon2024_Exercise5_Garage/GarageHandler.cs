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
        public bool RegisterNewVehicle()
        {

            // Registration Number, 6 chars 
            // Check all other vehicles RegistrationNumbers
            // and abort if duplicates are found. 

            // Wheels
            // PassengerLimit
            // VehicleType,
            // Color
            throw new NotImplementedException();
        }
        public bool RemoveVehicle()
        {
            throw new NotImplementedException();
        }
        public List<char> ParseRegistrationNumber()
        {
            string input;
            Console.WriteLine("Enter registration Number :");
            input = Console.ReadLine();
            return input.ToList();
        }
        public void CreateNewGarage(int i)
        {
            throw new NotImplementedException();
        }
        public int VehiclesInGarage() {
            return garage.Count();
        }
    }
}
