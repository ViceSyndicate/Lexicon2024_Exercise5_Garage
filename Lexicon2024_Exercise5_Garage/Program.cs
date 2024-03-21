namespace Lexicon2024_Exercise5_Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicles.Vehicle vehicle = new Vehicles.Vehicle();
            vehicle.RegistrationNumber = ['a', 'B', 'c', '1', '2', '3',];
            vehicle.Wheels = 2;
            vehicle.PassengerLimit = 3;
            vehicle.VehicleColor = Vehicles.Color.White;
            Manager garageManager = new Manager();
        }
    }
}