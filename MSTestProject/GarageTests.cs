using Lexicon2024_Exercise5_Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestProject
{
    [TestClass]
    public class GarageTests
    {
        /// <summary>
        /// Tests if the vehicle is succesfully stored at the first position
        /// in the T[] parkingSpots Array
        /// </summary>
        [TestMethod]
        public void TestParkVehicleAtIndexZero()
        {
            // Arrange
            var garage = new Lexicon2024_Exercise5_Garage.Garage<Vehicle>(4);
            var car = new Car("AbC123".ToCharArray(), 4, 5, Color.Red);

            // Act
            garage.ParkVehicle(car, position: 0);

            // Assert
            Assert.AreEqual(car, garage.GetVehiclesInGarage().FirstOrDefault());
        }
    }
}
