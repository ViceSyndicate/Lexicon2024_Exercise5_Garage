using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    internal class Car : Vehicle
    {
        public string Fueltype { get; set; }
        public Car(string fueltype, List<char> registrationNumber, int wheels, int passangerLimit, Color color, string fueltype) : base(registrationNumber, wheels, passangerLimit, color)
        {

            Fueltype = fueltype;    

        }
    }
}
