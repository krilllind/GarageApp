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
                Console.WriteLine("1. {0}\n2. {1}\n3. {2}\n0. {3}\n", "View garage.", "Add new garage.", "Save garage.","Exit Application.");
                
                int option = BaseLogic.CheckInput(Console.ReadLine(), "int");
                Console.Clear();
                switch (option)
                {
                    case 1:
                        if(gh.Garage == null)
                        {
                            Console.WriteLine("There is no garage in the system. Please create a new garage first!");
                            Console.ReadKey();
                            break;
                        }

                        while(true)
                        {
                            Console.WriteLine("Welcome to {0} garage!\n", gh.Garage.GarageName);
                            Console.WriteLine("1. {0}\n2. {1}\n3. {2}\n4. {3}\n0. {4}\n", "View vehicles in garage.", "Add new vehicle.", "Remove vehicle.", "Search for vechicles.", "Go back to main menu.");
                        
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

                                    Console.WriteLine("Add new vehicle to the garage.\n0. Go back.");

                                    Console.Write("What vehicle type do you want to add?\n(Car, Buss, Boat, Airplane, Motorcycle): ");
                                    string vehicleType = BaseLogic.CheckInput(Console.ReadLine(), "string", false, new List<string> { "car", "buss", "boat", "airplane", "motorcycle", "0" });

                                    if (vehicleType == "0")
                                        break;

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

                                    Console.Clear();
                                    Console.WriteLine("All information entered.\nDo you want to add the new {0} \"{1}\" to the garage? (Y/N)", vehicleType, vehicleName);

                                    char addNew = BaseLogic.CheckInput(Console.ReadLine(), "char", false, new List<string> { "y", "Y", "n", "N" });
                                    if (addNew == 'y')
                                    {
                                        Console.Clear();
                                        gh.AddNewVehicleToGarage(VehicleInformation);

                                        Console.WriteLine("New {0} \"{1}\" added to the garage!", vehicleType, vehicleName);
                                        Console.ReadKey();
                                    }
                                    break;

                                case 3:
                                    if (gh.Garage.VehiclesInGarage.Count() <= 0)
                                    {
                                        Console.WriteLine("There are no vehicle in he garage to be removed!");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("Enter the reg-num of the vehicle you want to remove.\n0. Go back.\n");
                                    string regnum = BaseLogic.CheckInput(Console.ReadLine(), "string");
                                    Console.Clear();

                                    if (regnum == "0")
                                        break;
                                    else if (gh.RemoveVehicle(regnum))
                                        Console.WriteLine("Vehicle successfully removed!");
                                    else
                                        Console.WriteLine("No vehicle was found with that reg-number.");

                                    Console.ReadKey();
                                    break;

                                case 4:
                                    if (gh.Garage.VehiclesInGarage.Count() <= 0)
                                    {
                                        Console.WriteLine("There are no vehicle in he garage to be searched for!");
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.WriteLine("How do you want to search?\n");
                                    Console.WriteLine("1. {0}\n2. {1}\n3. {2}\n0. {3}\n", "By name.", "By reg-num.", "By Color.", "Go back to garage view.");

                                    option = BaseLogic.CheckInput(Console.ReadLine(), "int");
                                    Console.Clear();

                                    if (option == 0)
                                        break;

                                    Console.Write("Enter searchterm: ");

                                    string searchTerm = BaseLogic.CheckInput(Console.ReadLine(), "string", true);
                                    string res = "";

                                    switch(option)
                                    {
                                        case 1:
                                            res = gh.SearchForVehicle("Name", searchTerm);
                                            break;

                                        case 2:
                                            res = gh.SearchForVehicle("RegNumber", searchTerm);
                                            break;

                                        case 3:
                                            res = gh.SearchForVehicle("Color", searchTerm);
                                            break;

                                        default:
                                            break;
                                    }

                                    Console.Clear();
                                    Console.WriteLine(res);
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
                    
                    case 3:
                        Console.WriteLine("Saving garage, please wait...");

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
