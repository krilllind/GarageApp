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

        public bool AddGarage(string garageName, int garageAmount = -1)
        {
            int x = 0;
            if(garageAmount == -1)
            {
                Random rand = new Random();
                x = rand.Next(0, 50);
            }
            else
            {
                x = garageAmount;
            }

            Garage = new Garage<Vehicle>(garageName, x);

            if (Garage != null)
                return true;
            else
                return false;
        }

        public string ViewAllVehicles()
        {
            string str = "";
            var q = Garage.VehiclesInGarage
                    .GroupBy(o => o.GetType())
                    .Select(o => new
                    {
                        count = o.Count(), type = o.Key.Name
                    });
                    
            foreach (var item in q)
                str += item.count + " vehicle of type " + item.type + ".\n";

            if(str.Length > 0)
                str += "\n";

            foreach (Vehicle v in Garage.VehiclesInGarage)
                str += v.ToString();

            if (str.Length <= 0)
                str = "There is no vehicles in the garage.";

            return str;
        }

        public void AddNewVehicleToGarage(Dictionary<string, dynamic> Specs)
        {
            string option = Specs["Type"].ToString();
            Specs["RegNumber"] = Specs["RegNumber"].ToString().ToUpper();
            Vehicle item = null;

            switch(option.ToLower())
            {
                case "car":
                    item = new Car(Specs["Name"], Specs["RegNumber"], Specs["Color"], Specs["NumberOfTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "buss":
                    item = new Buss(Specs["Name"], Specs["RegNumber"], Specs["Color"], Specs["NumberOfTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "boat":
                    item = new Boat(Specs["Name"], Specs["RegNumber"], Specs["Color"], Specs["NumberOfTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "airplane":
                    item = new Airplane(Specs["Name"], Specs["RegNumber"], Specs["Color"], Specs["NumberOfTires"], Specs["ModelYear"], Specs["NeedLicens"]);
                    break;
                case "motorcycle":
                    item = new Motorcycle(Specs["Name"], Specs["RegNumber"], Specs["Color"], Specs["NumberOfTires"], Specs["ModelYear"], Specs["NeedLicens"]);
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

            return false;
        }

        public string SearchForVehicle(string searchProp, string searchStr)
        {
            string str = "";
            IEnumerable<Vehicle> q = null;
            searchStr = searchStr.ToLower();

            try
            {
                q = Garage.Where(o =>
                    {
                        return o.GetType()
                            .GetProperty(searchProp)
                            .GetValue(o, null)
                            .ToString()
                            .ToLower()
                            .Contains(searchStr);
                    })
                    .OrderBy(o => o.Name);
            }
            catch (Exception) { }

            foreach (var vehicle in q)
                str += vehicle.ToString();

            if (str.Length <= 0)
                str = "No vehicle found!";

            return str;
        }

        public bool CarExists(string regNum)
        {
            Vehicle item = Garage.GetVehicleByREGNUM(regNum.ToUpper());

            if (item == null)
                return false;

            return true;
        }
    }
}
