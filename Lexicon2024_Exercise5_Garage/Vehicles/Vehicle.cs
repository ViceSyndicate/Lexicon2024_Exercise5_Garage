using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    internal class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; } // Unique
        public string Color { get; set; }
        public int Wheels { get; set; }
        public int PassengerLimit { get; set; }
    }
}
