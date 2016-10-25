using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageApplication.Classes;

namespace GarageApplication
{
    class GarageHandler
    {
        public Garage<Vehicle> Garage { get; private set; }

        public bool AddGarage(string garageName)
        {
            Random rand = new Random();
            int x = rand.Next(0, 50);

            Garage = new Garage<Vehicle>(garageName, x);

            if (Garage != null)
                return true;
            else
                return false;
        }

        public string ViewAllVehicles()
        {
            string str = "";

            foreach (Vehicle v in Garage.VehiclesInGarage)
            {
                str += v.ToString();
            }

            return str;
        }

        public void AddNewVehicleToGarage(Dictionary<string, dynamic> Specs)
        {
            string option = Specs["Type"].ToString();
            Specs["Regnum"] = Specs["Regnum"].ToString().ToUpper();
            Vehicle item = null;

            switch(option.ToLower())
            {
                case "car":
                    item = new Car(Specs["Name"], Specs["Regnum"], Specs["Color"], Specs["NumTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "buss":
                    item = new Buss(Specs["Name"], Specs["Regnum"], Specs["Color"], Specs["NumTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "boat":
                    item = new Boat(Specs["Name"], Specs["Regnum"], Specs["Color"], Specs["NumTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "airplane":
                    item = new Airplane(Specs["Name"], Specs["Regnum"], Specs["Color"], Specs["NumTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "motorcycle":
                    item = new Motorcycle(Specs["Name"], Specs["Regnum"], Specs["Color"], Specs["NumTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                default:
                    break;
            }

            if (item != null)
                Garage.AddVehicle(item);
        }

        public bool RemoveVehicle(string regNum)
        {
            Vehicle item = Garage.GetVehicleByREGNUM(regNum.ToUpper());

            if(item != null)
            {
                Garage.RemoveVehicle(item);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
