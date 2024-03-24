using Lexicon2024_Exercise5_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Interfaces
{
    internal interface IGarageHandler
    {
        bool TryParkVehicle(Vehicle vehicle);
        // Set Size  of Garage which takes a set size of IVehicle Array
        // or just Vehicle Array?

        // GetVehicleByRegistrationNr() Single Vehicle
        // GetVehicleByColor() arr/list of Vehicle
        // GetVehiclesInGarage arr/list of Vehicle
        // GetEmptySlotsInGarage Integer
        Dictionary<Type, int> GetDictOfVehicles();
        public List<Vehicle> GetVehicles();

        public Vehicle GetVehicle();
    }
}
