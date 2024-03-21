using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage
{
    internal class UI : IUI
    {
        public UI() { }

        void IUI.ShowMainMenu()
        {
            Console.WriteLine("1. Register New Vehicle");
            Console.WriteLine("2. Remove Vehicle from Garage");
            Console.WriteLine("3. Search For Vehicle In Garage"); // Open sub meny for search parameters,
                                                                  // With LINQBlack Vehicles, 4 Wheels, Trucks, Red Vehicles
            Console.WriteLine("4. List Vehicles In Garage"); // List Vehicle type and how many of each. 
            Console.WriteLine("8. Add Mock Vechiles To Garage");
            Console.WriteLine("9. Create New Garage");
            Console.WriteLine("0. Exit Program");

            string input;
            input = Console.ReadLine();
            switch (input)
            {
                case "1":; break;
                case "2":; break;
                case "3":; break;
                case "4":; break;
                case "9":
                    int garageSize = ParseInteger(); // Why is this giving me an error?
                    ; break;
                case "0": Environment.Exit(0); break;
                default: Console.WriteLine("Please enter a valid input: 1, 2, 3, 4 or 0."); break;
            }
        }
        // If I don't have IUI. it gives me an error. Why?
        int IUI.ParseInteger()
        {
            string input = Console.ReadLine();
            int garageSize;
            if(int.TryParse(input, out garageSize))
            {
                return garageSize;
            }
            else
            {
                throw new Exception("Failed to turn input in to an Number.");
            }
        }
    }
}
