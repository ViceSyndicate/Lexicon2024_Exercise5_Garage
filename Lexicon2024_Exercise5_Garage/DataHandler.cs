using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Lexicon2024_Exercise5_Garage
{
    internal class DataHandler
    {
        public static void SaveGarageToFile<T>(IEnumerable<T> vehicles, string filePath) where T : Vehicles.Vehicle
        {
            try
            {
                string json = JsonConvert.SerializeObject(vehicles);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving garage to file: {ex.Message}");
            }
        }

        public static IEnumerable<T> LoadGarageFromFile<T>(string filePath) where T : Vehicles.Vehicle
        {
            T[] vehicles = null!;
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    vehicles = JsonConvert.DeserializeObject<T[]>(json)!;
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading garage from file: {ex.Message}");
            }
            // Removes potential null values from the list.
            vehicles = vehicles.Where(item => item != null).ToArray();
            return vehicles;
        }
    }
}

