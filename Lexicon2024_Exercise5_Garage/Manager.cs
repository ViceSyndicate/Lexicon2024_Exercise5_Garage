using Lexicon2024_Exercise5_Garage.Interfaces;
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
                case 3: ui.SearchForVehicleMenu(); 
                    break;
                case 4: // List vehicles in garage
                    Dictionary<Type, int> vehicleCounts = garageHandler.GetDictOfVehicles();
                    ui.ShowVehiclesInGarage(vehicleCounts);

                    // send to UI for presentation.
                    ; break;
                case 5: ui.ShowAllVehiclesAndDetails(garageHandler.GetVehicles()); break;
                case 6:; break;
                case 8:; break;
                case 9:; break;
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