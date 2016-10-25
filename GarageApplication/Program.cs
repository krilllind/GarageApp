using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageHandler gh = new GarageHandler();

            while (true)
            {
                Console.WriteLine("Welcome to the garage. Choose between the options below:\n");
                Console.WriteLine("1. {0}\n2. {1}\n0. {2}\n", "View garage", "Add new garage", "Exit Application");
                
                int option = BaseLogic.CheckInput(Console.ReadLine(), "int");
                Console.Clear();
                switch (option)
                {
                    case 1:
                        if(gh.Garage == null)
                        {
                            Console.WriteLine("There is no garage in the system. Please add a new garage first!");
                            Console.ReadKey();
                            break;
                        }

                        while(true)
                        {
                            Console.WriteLine("Welcome to garage {0}.\n", gh.Garage.GarageName);
                            Console.WriteLine("1. {0}\n2. {1}\n3. {2}\n4. {3}\n0. {4}", "View vehicles in garage.", "Add new vehicle.", "Remove vehicle.", "Search for vechicles.", "Go to main menu.");
                        
                            option = BaseLogic.CheckInput(Console.ReadLine(), "int");
                            Console.Clear();

                            if (option == 0)
                                break;

                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine(gh.ViewAllVehicles());
                                    Console.ReadKey();
                                    
                                    break;

                                case 2:
                                    Dictionary<string, dynamic> VehicleInformation = new Dictionary<string, dynamic>();
                                    Console.WriteLine("Add new vehicle to the garage.\n");

                                    Console.Write("\nWhat vehicle type do you want to add?\n(Car, Buss, Boat, Airplane, Motorcycle): ");
                                    string vehicleType = BaseLogic.CheckInput(Console.ReadLine(), "string");
                                    VehicleInformation.Add("Type", vehicleType);

                                    Console.Write("\nEnter vehicle name: ");
                                    string vehicleName = BaseLogic.CheckInput(Console.ReadLine(), "string", true);
                                    VehicleInformation.Add("Name", vehicleName);

                                    Console.Write("\nEnter vehicle reg-num: ");
                                    string vehicleRegNum = BaseLogic.CheckInput(Console.ReadLine(), "string", true);
                                    VehicleInformation.Add("Regnum", vehicleRegNum);

                                    Console.Write("\nEnter vehicle color: ");
                                    string vehicleColor = BaseLogic.CheckInput(Console.ReadLine(), "string");
                                    VehicleInformation.Add("Color", vehicleColor);

                                    Console.Write("\nEnter number of tires on vehicle: ");
                                    int vehicleNumTires = BaseLogic.CheckInput(Console.ReadLine(), "int");
                                    VehicleInformation.Add("NumTires", vehicleNumTires);

                                    Console.Write("\nEnter vehicle model year: ");
                                    int vehicleModleYear = BaseLogic.CheckInput(Console.ReadLine(), "int");
                                    VehicleInformation.Add("ModelYear", vehicleModleYear);

                                    Console.Write("\nDo you need a licens to drive this vehicle? (Y/N): ");
                                    char vehicleLicens = BaseLogic.CheckInput(Console.ReadLine(), "char", false, new List<string> { "y", "Y", "n", "N" });
                                    bool vehicleLicensNeeded;

                                    if (vehicleLicens == 'y')
                                        vehicleLicensNeeded = true;
                                    else
                                        vehicleLicensNeeded = false;

                                    VehicleInformation.Add("NeedLicens", vehicleLicensNeeded);

                                    Console.WriteLine("\nDo you want to add the new vehicle " + vehicleName + "? (Y/N)");
                                    char addNew = BaseLogic.CheckInput(Console.ReadLine(), "char", false, new List<string> { "y", "Y", "n", "N" });

                                    if (addNew == 'y')
                                    {
                                        Console.Clear();
                                        gh.AddNewVehicleToGarage(VehicleInformation);

                                        Console.WriteLine("New vehicle added!");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Enter the reg-num of the vehicle you want to remove.\n");
                                    string regnum = BaseLogic.CheckInput(Console.ReadLine(), "string");

                                    Console.Clear();
                                    if(gh.RemoveVehicle(regnum))
                                        Console.WriteLine("Vehicle successfully removed!");
                                    else
                                        Console.WriteLine("No vehicle was found with that reg-number.");

                                    Console.ReadKey();
                                    break;

                                case 4:
                                    Console.WriteLine("How do you want to search?\n");
                                    Console.WriteLine("1. {0}\n2. {1}\n3. {2}", "By name.", "By reg-num.", "By Color.");
                                    Console.ReadKey();
                                    break;

                                default:
                                    break;
                            }

                            Console.Clear();
                        }
                        break;

                    case 2:
                        if(gh.Garage != null)
                        {
                            Console.WriteLine("There is already a garage named \"{0}\" in the system.\nDo you want to override it? (Y/N)", gh.Garage.GarageName);
                            char overrideGarage = BaseLogic.CheckInput(Console.ReadLine(), "char", false, new List<string> { "y", "Y", "n", "N" });

                            Console.Clear();
                            if (overrideGarage == 'n')
                                break;
                        }

                        Console.WriteLine("What is the name of the garage?\n");
                        string garageName = BaseLogic.CheckInput(Console.ReadLine(), "string");
                        Console.Clear();

                        bool addGarage = gh.AddGarage(garageName);
                        if (addGarage)
                            Console.WriteLine("New garage \"" + garageName + "\" added!");
                        else
                            Console.WriteLine("Could not add the new garage to the application. Please try again!");

                        Console.ReadKey();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }

                Console.Clear();
            }

        }
    }
}
