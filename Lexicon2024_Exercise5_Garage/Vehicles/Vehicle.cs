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
        private List<char> registrationNumber;
        private int wheels;
        private int passangerLimit;
        private Color color;

        public List<char> RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; } // Hope this works!
        } // Unique
        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }
        public int PassengerLimit
        {
            get { return passangerLimit; }
            set { PassengerLimit = value; }
        }
        public Color VehicleColor
        {
            get { return color; }
            set { color = value; }
        }
    }
    enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Purple,
        Pink,
        White,
        Gray,
        Black,
        Multicolored
    }
}
