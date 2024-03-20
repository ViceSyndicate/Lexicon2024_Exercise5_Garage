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
        private T[] vehicles;
        public Garage(int capacity)
        {
            vehicles = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
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