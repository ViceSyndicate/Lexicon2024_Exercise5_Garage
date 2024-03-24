using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    public class Vehicle : IVehicle
    {
        private char[] registrationNumber;
        private int wheels;
        private int passangerLimit;
        private Color color;

        public Vehicle()
        {

        }
        public Vehicle(char[] registrationNumber, int wheels, int passangerLimit, Color color)
        {
            for (int i = 0; i < registrationNumber.Length; i++)
            {
                Char.ToUpper(registrationNumber[i]);
            }
            this.registrationNumber = RegistrationNumber;
            this.wheels = Wheels;
            this.passangerLimit = PassengerLimit;
            this.color = VehicleColor;
        }

        public char[] RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value.Count() > 8)
                {
                    throw new ArgumentException("Registration number needs to be 8 characters.");
                }
                registrationNumber = value;
            }
        }
        public int Wheels
        {
            get { return wheels; }
            set
            {
                if (value < 0) { throw new ArgumentException("PassengerLimit can't be a negative number."); }
                wheels = value;
            }
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
    public enum Color
    {
        Red,
        Green,
        Blue,
        //Yellow,
        //Cyan,
        //Purple,
        //Pink,
        White,
        //Gray,
        Black,
        Other
    }
}