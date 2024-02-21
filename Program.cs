
using System;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ParkingSystem parkingSystem = new ParkingSystem();
            parkingSystem.Run();
        }
    }

    class ParkingSystem
    {
        public string PlateNum { get; set; }
        public string Brand { get; set; }
        public DateTime TimeIn { get; set; }

        public void Run()
        {
            int option;
            bool isvalidOption;
            do
            {
                isvalidOption = false;
                Console.WriteLine("OVERNIGHT PARKING IS NOT ALLOWED \n");
                Console.WriteLine("Please select your vehicle type below:");
                Console.WriteLine("1. Motor Bike");
                Console.WriteLine("2. SUV");
                Console.WriteLine("3. Van");
                Console.WriteLine("4. Sedan");
                Console.Write("Enter Vehicle Type: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        HandleVehicleType("Motor Bike");
                        break;
                    case 2:
                        HandleVehicleType("SUV");
                        break;
                    case 3:
                        HandleVehicleType("Van");
                        break;
                    case 4:
                        HandleVehicleType("Sedan");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a number between 1 and 4.");
                        break;
                }
                Console.ReadKey();
            }
            while (!isvalidOption);
        } 

        private void HandleVehicleType(string vehicleType)
        {
            string exitTimeInput;
            DateTime timeOut;
            double totalHours, parkingCost;

            Console.Write("Enter Car Brand: ");
            Brand = Console.ReadLine();
            Console.Write("Enter vehicle's plate number: ");
            PlateNum = Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("VIHICLE INFORMATION!");
            Console.WriteLine("Plate No: " + PlateNum);
            Console.WriteLine("Type: " + vehicleType);
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("\n");
            TimeIn = DateTime.Now;
            Console.WriteLine("Time in: " + TimeIn);

            bool isValid;
            do
            {
                isValid = false;
                Console.Write("Enter Time Out (HH:mm:ss): ");
                exitTimeInput = Console.ReadLine();
                if (DateTime.TryParseExact(exitTimeInput, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out timeOut))
                {
                    TimeSpan duration = timeOut - TimeIn;
                    totalHours = duration.TotalHours;
                    parkingCost = ((totalHours - 1) * GetHourlyRate(vehicleType)) + GetBaseRate(vehicleType);

                    if (totalHours < 1)
                    {
                        parkingCost = GetBaseRate(vehicleType);
                    }

                    Console.WriteLine("Duration of parking: " + duration);
                    Console.WriteLine("Parking Cost: " + parkingCost);
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid time format. Please enter time in HH:mm:ss format.");
                }
            }
            while (!isValid);
        }

        private double GetHourlyRate(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Motor Bike":
                    return 5;
                case "SUV":
                case "Van":
                    return 20;
                case "Sedan":
                    return 15;
                default:
                    return 0;
            }
        }

        private double GetBaseRate(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Motor Bike":
                    return 20;
                case "SUV":
                case "Van":
                    return 40;
                case "Sedan":
                    return 30;
                default:
                    return 0;
            }
        }
    }
}
