using Lexicon2024_Exercise5_Garage.Interfaces;
using Lexicon2024_Exercise5_Garage.Vehicles;
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
        // Why is UI gray but Garage is not when I set both in the CTOR?
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

            short menuResult = AwaitMenuResult();
            while (menuResult != 0)
            {
                menuResult = AwaitMenuResult();
            }
            //int vehiclesInGarage = garageHandler.VehiclesInGarage();
        }
        public short AwaitMenuResult()
        {
            int uiResult = ui.ShowMainMenu();
            short returnVal = 1;
            switch(uiResult)
            {
                case 1: Vehicle vehicle = ui.RegisterNewVehicle(); 
                    // Check if RegNr already exists in garage. If it does: Abort.
                    // Add vehicle to Garage with GarageHandler.
                    break;
                case 2: ; break;
                case 3: ; break;
                case 4: // List vehicles in garage
                    Dictionary<Type, int> vehicleCounts = garageHandler.VehiclesInGarage();
                    ui.ShowVehiclesInGarage(vehicleCounts);
                    
                    // send to UI for presentation.
                    ; break;
                case 8: ; break;
                case 9: ; break;
                case 0: returnVal = 0; break;
                    default: break;
            }
            return returnVal;
        }
        
    }
}