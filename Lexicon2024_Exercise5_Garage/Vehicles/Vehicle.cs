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
            // ensure uppercase
            string regString = new string(registrationNumber);

            regString = regString.ToUpper();

            registrationNumber = regString.ToArray();

            RegistrationNumber = registrationNumber;
            Wheels = wheels;
            PassengerLimit = passangerLimit;
            VehicleColor = color;
        }

        public char[] RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value.Count() > 8)
                {
                    throw new ArgumentException("Registration number needs to be less than 8 characters.");
                }
                registrationNumber = value;
            }
        }
        public int Wheels
        {
            get { return wheels; }
            set
            {
                if (wheels < 0)
                {
                    wheels = 0;
                }
                else
                {
                    wheels = value;
                }
            }
        }
        public int PassengerLimit
        {
            get { return passangerLimit; }
            set
            {
                if (passangerLimit < 0)
                {
                    passangerLimit = 0;
                }
                else
                {
                    passangerLimit = value;
                }
            }
        }
        public Color VehicleColor
        {
            get { return color; }
            set
            { color = value; }
        }
        /**/
        public override string ToString()
        {
            string regNr = new string(RegistrationNumber);

            return $"RegNr: {regNr} " +
                $"Passanger Seats: {passangerLimit} " +
            $"Wheels: {wheels} " +
            $"Color: {color}";
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