using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }
        public Motorcycle(char[] registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            
        }
        public Motorcycle(int cylinderVolume, char[] registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
