using Lexicon2024_Exercise5_Garage.Interfaces;
using Lexicon2024_Exercise5_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage
{
    internal class Manager
    {
        IUI ui;
        IGarageHandler garageHandler;
        public Manager()
        {
            ui = new UI();
            garageHandler = new GarageHandler(32);

            short menuResult = AwaitMenuResult();
            while (menuResult != 0)
            {
                menuResult = AwaitMenuResult();
            }
        }
        public short AwaitMenuResult()
        {
            int uiResult = ui.ShowMainMenu();
            short returnVal = 1;
            switch(uiResult)
            {
                case 1: 
                    Vehicle vehicle = ui.RegisterNewVehicle();
                    bool success = garageHandler.TryParkVehicle(vehicle);
                    if(success)
                    {
                        // Call UI to print Added Vehicle Or just print it here...
                        Console.WriteLine("Vehicle Parked!");
                    }
                    else
                    {
                        // Call UI to print Failed to add Vehicle
                        Console.WriteLine("Failed to park Vehicle!");
                    }
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
                    case 5: TMockCar(); break;
                case 8: ; break;
                case 9: ; break;
                case 0: returnVal = 0; break;
                    default: break;
            }
            return returnVal;
        }
        // Creates a car.
        public void TMockCar()
        {
            char[] regplate = ['1', '2', '3', 'a', 'b', 'c'];
            Vehicle vehicle = new Car(regplate, 2, 2, Vehicles.Color.White);
            bool success = garageHandler.TryParkVehicle(vehicle);
        }
    }
}