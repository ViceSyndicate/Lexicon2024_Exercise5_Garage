using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    internal class Bus : Vehicle
    {
        public int StandingSpots { get; set; }
        public Bus(char[] registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            
        }
        public Bus(int standingSpots, char[] registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            StandingSpots = standingSpots;
        }
    }
}
