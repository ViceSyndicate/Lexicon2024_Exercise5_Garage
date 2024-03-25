﻿using Lexicon2024_Exercise5_Garage.Interfaces;
using Lexicon2024_Exercise5_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage
{
    internal class UI : IUI
    {
        public UI() { }

        public int ShowMainMenu()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Register New Vehicle");
            Console.WriteLine("2. Remove Vehicle from Garage");
            Console.WriteLine("x3. Search For Vehicle In Garage"); // Open sub meny for search parameters,
            Console.WriteLine("4. List Vehicles In Garage"); // List Vehicle type and how many of each. 
            Console.WriteLine("5. List All Vehicles & Information.");
            Console.WriteLine("x9. Create New Garage");
            Console.WriteLine("0. Exit Program");

            string input;
            input = Console.ReadLine();
            switch (input)
            {
                case "1": return 1; break;
                case "2": return 2; break;
                case "3": return 3; break;
                case "4": return 4; break;
                case "5": return 5; break;
                case "6": return 6; break;
                case "8": return 8; break;
                case "9":
                    return 9; break;
                    // int garageSize = ParseInteger();
                    break;
                case "0":
                    Environment.Exit(0);
                    return 0;
                    break;
                default:
                    Console.WriteLine("Please enter a valid input: 1, 2, 3, 4, 8, 9 or 0.");
                    return 0;
                    break;
            }
        }

        public char[] RemoveVehicle(List<char[]> regNumbers)
        {
            Console.WriteLine("RegistrationNumbers In the Garage.");
            foreach (var regNumber in regNumbers)
            {
                foreach(char c in regNumber)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            string input = Console.ReadLine();
            char[] regNrToDelete = input.ToCharArray();
            return regNrToDelete;
        }

        public int ParseInteger()
        {
            string input = Console.ReadLine();
            int garageSize;
            if (int.TryParse(input, out garageSize))
            {
                return garageSize;
            }
            else
            {
                return -1;
                //throw new Exception("Failed to turn input in to an Number.");
            }
        }
        public Vehicle RegisterNewVehicle()
        {
            // I should probably ask for vehicle type first...
            Console.WriteLine("Please select a vehicle type. ");
            Console.WriteLine();
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Bus");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Airplane");


            char[] regNr;
            int wheels;
            int passangerLimit;
            Color color;
            Vehicle vehicle;
            int vehicleType; // Decides the Class type we create. 

            string input = Console.ReadLine();
            // Deal with the specific vehicle types later.
            switch (input)
            {
                case "1": vehicleType = 1; break;
                case "2": vehicleType = 2; break;
                case "3": vehicleType = 3; break;
                case "4": vehicleType = 4; break;
                case "5": vehicleType = 5; break;
                default: vehicleType = 0; break; // how to handle this...
            }

            string regNrInput;
            Console.WriteLine("Enter Registration Number: ");
            regNrInput = Console.ReadLine();
            regNr = regNrInput.ToCharArray();
            // Check regNr in garage for duplicates...

            Console.WriteLine("enter how many wheels the vehicle has: ");
            wheels = ParseInteger();
            if(wheels == -1)
            {
                throw new FormatException();
            }

            Console.WriteLine("Enter how many passenger spots: ");
            passangerLimit = ParseInteger();
            if (passangerLimit == -1)
            {
                throw new FormatException();
            }
            Console.WriteLine("Select a color.");

            Console.WriteLine("1. Red");
            Console.WriteLine("2. Green");
            Console.WriteLine("3. Blue");
            Console.WriteLine("4. White");
            Console.WriteLine("5. Black");
            Console.WriteLine("6. Other");
            input = Console.ReadLine();
            switch (input)
            {
                case "1": color = Color.Red; break;
                case "2": color = Color.Green; break;
                case "3": color = Color.Blue; break;
                case "4": color = Color.White; break;
                case "5": color = Color.Black; break;
                case "6": color = Color.Other; break;
                default:  color = Color.Other; break;
            }
            // I think the mistake is creating the car here. I should just return it.
            switch (vehicleType)
            {
                case 1: vehicle = new Car(regNr, wheels, passangerLimit, color);break;
                case 2: vehicle = new Car(regNr, wheels, passangerLimit, color); break;
                case 3: vehicle = new Car(regNr, wheels, passangerLimit, color); break;
                case 4: vehicle = new Car(regNr, wheels, passangerLimit, color); break;
                case 5: vehicle = new Car(regNr, wheels, passangerLimit, color); break;
                default : vehicle = new Vehicle(regNr, wheels, passangerLimit, color); break;
            }
            return vehicle;
        }

        public void ShowAllVehiclesAndDetails(List<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null) { Console.WriteLine(vehicle.ToString()); }
            }
        }
        public void ShowVehiclesInGarage(Dictionary<Type, int> vehicleCounts)
        {
            Console.WriteLine("Garage Contains ");
            foreach (var vehicle in vehicleCounts)
            {
                Console.WriteLine($"{vehicle.Key.Name} : {vehicle.Value}");
            }
        }
        public void SearchForVehicleMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Search by Registration Number");
            Console.WriteLine("2. Search by nr of Wheels");
            Console.WriteLine("3. Search by Passanger Spots");
            Console.WriteLine("4. Search by Color");
            string input = Console.ReadLine();

        }
    }
}