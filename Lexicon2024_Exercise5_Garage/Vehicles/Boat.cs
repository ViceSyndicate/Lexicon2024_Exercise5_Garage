using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public Boat(int numberOfEngines, string fueltype, List<char> registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
