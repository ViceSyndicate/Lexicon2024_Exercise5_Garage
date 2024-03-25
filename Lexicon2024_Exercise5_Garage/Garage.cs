using Lexicon2024_Exercise5_Garage.Vehicles;
using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;

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
        public void ParkVehicle(T vehicle, int position)
        {
            try { parkingSpots[position] = vehicle; }
            catch { throw new Exception(); };
        }
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
        public bool RemoveVehicle(char[] registrationNumber)
        {
            int index = Array.FindIndex(parkingSpots, v => v != null && v.RegistrationNumber.SequenceEqual(registrationNumber));
            if (index == -1)
            {
                return false;
            }
            else
            {
                parkingSpots[index] = null;
                return true;
            }
        }
        public List<char[]> GetRegNrs()
        {
            List<char[]> regNrsList = parkingSpots
                .Where(v => v != null && v.RegistrationNumber != null)
                .Select(vehicle => vehicle.RegistrationNumber)
                .ToList();
            return regNrsList;
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