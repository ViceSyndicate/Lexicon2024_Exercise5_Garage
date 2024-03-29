﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int Wingspan { get; set; }
        public Airplane(char[] registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            
        }
        public Airplane(int wingspan, char[] registrationNumber, int wheels, int passangerLimit, Color color) : base(registrationNumber, wheels, passangerLimit, color)
        {
            Wingspan = wingspan;
        }
    }
}
