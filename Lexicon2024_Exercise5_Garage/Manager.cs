﻿using Lexicon2024_Exercise5_Garage.Interfaces;
using Lexicon2024_Exercise5_Garage.Vehicles;

namespace Lexicon2024_Exercise5_Garage
{
    internal class Manager
    {
        IUI ui;
        IGarageHandler garageHandler;
        public Manager()
        {
            ui = new UI();
            int garageSize = ui.SetGarageSize();
            garageHandler = new GarageHandler(garageSize);

            short menuResult = AwaitMenuResult();
            while (menuResult != 0)
            {
                menuResult = AwaitMenuResult();
            }
        }

        public short AwaitMenuResult()
        {
            int uiResult = ui.ShowMainMenu();
            switch (uiResult)
            {
                case 1:
                    try
                    {
                        Vehicle vehicle = ui.RegisterNewVehicle();
                        bool success = garageHandler.TryParkVehicle(vehicle);
                        if (success)
                        {
                            // Call UI to print Added Vehicle Or just print it here...
                            Console.WriteLine("Vehicle Parked!");
                        }
                        else
                        {
                            // Call UI to print Failed to add Vehicle
                            Console.WriteLine("Failed to park Vehicle!");
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }


                    // Check if RegNr already exists in garage. If it does: Abort.
                    // Add vehicle to Garage with GarageHandler.
                    break;
                case 2:
                    List<char[]> regNrs = garageHandler.GetRegistrationNumbers();
                    char[] regNrToRemove = ui.RemoveVehicle(regNrs);
                    if (garageHandler.RemoveVehicle(regNrToRemove)) Console.WriteLine("Vehicle Removed!");
                    else Console.WriteLine("Could not remove Vehicle!");

                    break;
                case 3:
                    int searchSelection = ui.SearchForVehicleMenu();
                    string searchQuery;
                    Dictionary<int, Vehicle> results;
                    switch (searchSelection)
                    {
                        case 1:
                            searchQuery = ui.GetSearchQuery();
                            results = garageHandler.GetVehicleByRegNr(searchQuery);
                            ui.PresentSearchResult(results);
                            break; //Registration Number
                        case 2:
                            searchQuery = ui.GetSearchQuery();
                            results = garageHandler.GetVehiclesyNrOfWheels(searchQuery);
                            ui.PresentSearchResult(results);
                            break; // nr of Wheels
                        case 3:
                            searchQuery = ui.GetSearchQuery();
                            results = garageHandler.GetVehiclesByPassengerSpots(searchQuery);
                            ui.PresentSearchResult(results);
                            break; // PassengerSpots
                        case 4:
                            Color color = ui.GetColor();
                            results = garageHandler.GetVehiclesByColor(color);
                            ui.PresentSearchResult(results);
                            break; // Color
                        default:
                            break;
                    }
                    break;
                case 4: // List vehicles in garage
                    Dictionary<Type, int> vehicleCounts = garageHandler.GetDictOfVehicles();
                    ui.ShowVehiclesInGarage(vehicleCounts);
                    ; break;
                case 5: ui.ShowAllVehiclesAndDetails(garageHandler.GetVehicles()); break;
                case 6:; break;
                case 8:
                    if (garageHandler.AddMockVehiclesToGarage())
                    {
                        Console.WriteLine("Added Mock Vehicles!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Mock Vehicles. \n" +
                            "Maybe you already added them or there are Registration Number Duplicates?");
                    };
                    break; // 8. Add Mock Vehicles 
                case 9: garageHandler = new GarageHandler(ui.SetGarageSize()); break;

                case 11:
                    List<Vehicle> parkedVehicles = garageHandler.GetVehicles();
                    DataHandler.SaveGarageToFile(parkedVehicles, "garage.json");
                    Console.WriteLine("Saved Parked vehicles to garage.json!");
                    break;
                case 12:
                    var savedVehicles = DataHandler.LoadGarageFromFile<Vehicle>("garage.json");
                    foreach (Vehicle vehicle in savedVehicles)
                    {
                        if (garageHandler.TryParkVehicle(vehicle))
                        { Console.WriteLine("Parked New Vehicle from File!"); }
                        else { Console.WriteLine("Failed to park Vehicle from File!"); }
                    }
                    break;
                case 0:; break;
            }
            return 99; // I am aware magic variables are bad. 
            // To stay in loop. if we return 0 we end loop.
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