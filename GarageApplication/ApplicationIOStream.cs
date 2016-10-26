using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GarageApplication.Classes;
using System.Threading;

namespace GarageApplication
{
    class ApplicationIOStream
    {
        private string IO_dir = null;
        private string Database_loc = "/Database/";
        private string User_loc = "/Users/";
        private string Database_file = ".Data.garage";

        public bool FoundLoadableFile = false;
        public List<Dictionary<string, dynamic>> VehicleSpecs { get; private set; }
        public string GarageName { get; private set; }
        public int GarageMaxSize { get; private set; }

        public ApplicationIOStream(string dir)
        {
            this.IO_dir = @"" + dir + "/System/";

            if (!Directory.Exists(this.IO_dir + this.Database_loc))
                Directory.CreateDirectory(this.IO_dir + this.Database_loc);

            if (!Directory.Exists(this.IO_dir + this.User_loc))
                Directory.CreateDirectory(this.IO_dir + this.User_loc);
        }

        public bool Save(Garage<Vehicle> garage)
        {
            Animation();

            string path = this.IO_dir + this.Database_loc + garage.GarageName + this.Database_file;
            DateTime dt = DateTime.Now;

            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();
            }    

            TextWriter tw = new StreamWriter(path);
            tw.WriteLine("# Database table containing information about garage vehicles.");
            tw.WriteLine("# File created " + dt);

            tw.WriteLine("GarageName=" + garage.GarageName);
            tw.WriteLine("GarageMaxAmount=" + garage.MaxAmountInGarage);

            foreach (var item in garage.VehiclesInGarage)
            {
                tw.Write("\n");
                tw.WriteLine("Type=" + item.GetType().ToString().Split('.').Last());
                tw.WriteLine("Name=" + item.Name);
                tw.WriteLine("RegNumber=" + item.RegNumber);
                tw.WriteLine("Color=" + item.Color);
                tw.WriteLine("NumberOfTires=" + item.NumberOfTires);
                tw.WriteLine("ModelYear=" + item.ModelYear);
                tw.WriteLine("NeedLicens=" + item.NeedLicens);
                tw.WriteLine("~");
            }

            tw.Close();

            if (File.Exists(path))
                return true;
            else
                return false;
        }

        public void Load()
        {
            string path = this.IO_dir + this.Database_loc;
            if (!Directory.EnumerateFileSystemEntries(path).Any())
                return;

            DirectoryInfo di = new DirectoryInfo(path);
            string FirstFileName =
                    di.GetFiles()
                    .Select(f => f.Name)
                    .FirstOrDefault(name => name != null);


            if((FirstFileName.Length > 0) && (FirstFileName.Split('.').Last() == "garage"))
            {
                FoundLoadableFile = true;
                VehicleSpecs = new List<Dictionary<string, dynamic>>();

                StreamReader sr = new StreamReader(path + FirstFileName);
                Dictionary<string, dynamic> tmp = new Dictionary<string, dynamic>();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length <= 0 || line[0] == '#')
                        continue;
                    else if (line[0] == '~')
                    {
                        VehicleSpecs.Add(tmp);
                        tmp = new Dictionary<string, dynamic>();
                        continue;
                    }

                    string[] l = line.Split('=');
                    l[1].Trim();

                    switch(l[0].Trim())
                    {
                        case "GarageName":
                            this.GarageName = l[1];
                            break;
                        case "GarageMaxAmount":
                            this.GarageMaxSize = BaseLogic.CheckInput(l[1], "int");
                            break;
                        case "Type":
                            tmp.Add("Type", l[1]);
                            break;
                        case "Name":
                            tmp.Add("Name", l[1]);
                            break;
                        case "RegNumber":
                            tmp.Add("RegNumber", l[1]);
                            break;
                        case "Color":
                            tmp.Add("Color", l[1]);
                            break;
                        case "NumberOfTires":
                            tmp.Add("NumberOfTires", BaseLogic.CheckInput(l[1], "int"));
                            break;
                        case "ModelYear":
                            tmp.Add("ModelYear", BaseLogic.CheckInput(l[1], "int"));
                            break;
                        case "NeedLicens":
                            tmp.Add("NeedLicens", bool.Parse(l[1]));
                            break;
                        default:
                            break;
                    }
                }

                sr.Close();
            }  
        }

        public bool RemoveData(string Match)
        {
            Animation(4);

            string path = this.IO_dir + this.Database_loc;
            if (!Directory.EnumerateFileSystemEntries(path).Any())
                return false;

            DirectoryInfo di = new DirectoryInfo(path);
            string FirstFileName =
                    di.GetFiles()
                    .Select(f => f.Name)
                    .FirstOrDefault(name => name != null);

            if(FirstFileName.Split('.').First().ToLower() == Match.ToLower())
            {
                File.Delete(path + FirstFileName);
                return true;
            }

            return false;
        }

        private void Animation(int aniTime = 6)
        {
            string str = "Saving changes";
            string tmp = str;

            if (aniTime % 2 != 0)
                aniTime += 1;

            for (int i = 0; i < aniTime; i++)
            {
                tmp += ".";
                if (i == (aniTime / 2))
                    tmp = str;

                Console.Clear();
                Console.Write(tmp);
                Thread.Sleep(500);
            }

            Console.Clear();
        }
    }
}
