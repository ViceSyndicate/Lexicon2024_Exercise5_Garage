using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage
{
    internal class Manager
    {
        IUI ui;
        IGarageHandler garageHandler;

        int vehiclesInGarage;
        //GarageHandler garageHandler = new GarageHandler(32);
        public Manager()
        {
            // Create UI
            // CreateGarage
            ui = new UI();
            garageHandler = new GarageHandler(32);
            //CreateGarage(32);
            VehiclesInGarage();
        }
        public void CreateGarage(int parkingSpots)
        {
            garageHandler = new GarageHandler(parkingSpots);
        }

        //int vehiclesInGarage = garageHandler.VehiclesInGarage();

        public int VehiclesInGarage()
        {
            Console.WriteLine("Vehicles In Garage: " + garageHandler.VehiclesInGarage());
            return garageHandler.VehiclesInGarage();
        }


    }
}
