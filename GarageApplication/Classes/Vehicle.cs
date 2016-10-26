using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes
{
    class Vehicle
    {
        public string Name { get; private set; }
        public string RegNumber { get; private set; }
        public string Color { get; private set; }
        public int NumberOfTires { get; private set; }
        public int ModelYear { get; private set; }
        public bool NeedLicens { get; private set; }

        /// <summary>
        /// <para>Vehicle name, Vehicle reg-num, Vehicles color, Number of tires, Model-year, Do you need a licens to drive it?</para>
        /// <seealso cref="GarageApplication.Classes.Vehicle"/>
        /// </summary>
        public Vehicle(string name, string regnum, string color, int numberoftires, int modelyear, bool needlicens = true)
        {
            this.Name = name;
            this.RegNumber = regnum;
            this.Color = color;
            this.NumberOfTires = numberoftires;
            this.ModelYear = modelyear;
            this.NeedLicens = needlicens;
        }

        /// <summary>
        /// <para>Change color of vehicle</para>
        /// <seealso cref="GarageApplication.Classes.Vehicle.ChangeColor"/>
        /// </summary>
        public void ChangeColor(string newColor)
        {
            this.Color = newColor;
        }

        /// <summary>
        /// <para>Change the state if you need a licens to drive the vehicle or not.</para>
        /// <seealso cref="GarageApplication.Classes.Vehicle.MustHaveLicens"/>
        /// </summary>
        public void MustHaveLicens(bool licens)
        {
            this.NeedLicens = licens;
        }

        /// <summary>
        /// <para>Returns a string of information about the vehicle.</para>
        /// <seealso cref="GarageApplication.Classes.Vehicle.ToString"/>
        /// </summary>
        public override string ToString()
        {
            string licens = "";

            if (this.NeedLicens)
                licens = "YES";
            else
                licens = "NO";

            return "Name: " + this.Name + "\nType: " + this.GetType().ToString().Split('.').Last() + "\nColor: " + this.Color + "\nModel year: " + this.ModelYear + "\nRequire licens: " + licens + "\nReg-num: " + this.RegNumber + "\n\n";
        }
    }
}
