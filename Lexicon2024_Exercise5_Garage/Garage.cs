using Lexicon2024_Exercise5_Garage.Vehicles;
using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lexicon2024_Exercise5_Garage
{
    // where T : Vehicle,
    internal class Garage<T> : IEnumerable<T>, IGarage where T : Vehicle
    {
        private T[] parkingSpots;
        public Garage(int capacity)
        {
            parkingSpots = new T[capacity];
        }
        public T[] GetVehiclesInGarage() { return parkingSpots; }
        public bool TryParkVehicle(T vehicle)
        {
            bool parkedFlag = false;
            try
            {
                // Check if garage is full
                if (parkingSpots.All(v => v != null))
                {
                    return false;
                }

                if (parkingSpots.Any(v => v != null && v.RegistrationNumber == vehicle.RegistrationNumber))
                {
                    return false;
                }

                for (int i = 0; i < parkingSpots.Length; i++)
                {
                    if (parkingSpots[i] == null)
                    {
                        parkingSpots[i] = vehicle;
                        parkedFlag = true;
                        break; // Found an empty spot. Loop looking for an empty(null) spot.
                    }
                    else
                    {
                        parkedFlag = false;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return parkedFlag;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in parkingSpots)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}