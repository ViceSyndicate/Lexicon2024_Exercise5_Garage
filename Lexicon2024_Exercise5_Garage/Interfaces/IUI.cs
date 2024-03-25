using Lexicon2024_Exercise5_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Interfaces
{
    public interface IUI
    {
        int ShowMainMenu();
        int ParseInteger();
        public Vehicle RegisterNewVehicle();
        void ShowVehiclesInGarage(Dictionary<Type, int> vehicleCounts);
        void ShowAllVehiclesAndDetails(List<Vehicle> vehicles);
        char[] RemoveVehicle(char[] regNumbers);
    }
}