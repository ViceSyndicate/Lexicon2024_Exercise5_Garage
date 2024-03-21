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

        public Vehicle(List<char> registrationNumber, int wheels, int passangerLimit, Color color)
        {
            this.registrationNumber = registrationNumber;
            this.wheels = wheels;
            this.passangerLimit = passangerLimit;
            this.color = color;
        }
        
        public List<char> RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value.Count() > 6)
                {
                    throw new ArgumentException("Registration number needs to be 6 characters.");
                }
                registrationNumber = value;
            }
        }
        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }
        public int PassengerLimit
        {
            get { return passangerLimit; }
            set
            {
                if (value < 0) { throw new ArgumentException("PassengerLimit can't be a negative number."); }
                passangerLimit = value;
            }
        }
        public Color VehicleColor
        {
            get { return color; }
            set
            { color = value; }

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