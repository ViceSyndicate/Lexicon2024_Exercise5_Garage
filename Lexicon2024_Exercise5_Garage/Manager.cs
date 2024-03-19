using Lexicon2024_Exercise5_Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon2024_Exercise5_Garage
{
    internal class Manager
    {
        IUI ui = new UI();
        IGarageHandler garageHandler = new GarageHandler();
    }
}
