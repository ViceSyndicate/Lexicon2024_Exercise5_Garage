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
            //GarageHandler garageHandler = new GarageHandler(32);
            garageHandler = new GarageHandler(32);
            int vehiclesInGarage = garageHandler.VehiclesInGarage();
        }
    }
}
