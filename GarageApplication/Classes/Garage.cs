using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public List<T> VehiclesInGarage { get; private set; }
        public int MaxAmountInGarage { get; private set; }
        public string GarageName { get; private set; }

        /// <summary>
        /// <para>Specify garagesize (0-50).</para>
        /// <seealso cref="GarageApplication.Classes.Garage"/>
        /// </summary>
        public Garage(string garageName, int maxGarageSize)
        {
            VehiclesInGarage = new List<T>();
            this.GarageName = garageName;

            if (maxGarageSize < 1)
                this.MaxAmountInGarage = 1;
            else if (maxGarageSize > 50)
                this.MaxAmountInGarage = 50;
            else
                this.MaxAmountInGarage = maxGarageSize;
        }

        /// <summary>
        /// <para>Adds a new Vehicle to the garage.</para>
        /// <seealso cref="GarageApplication.Classes.Garage.AddVehicle"/>
        /// </summary>
        public bool AddVehicle(T item)
        {
            if (VehiclesInGarage.Count() >= MaxAmountInGarage)
                return false;

            VehiclesInGarage.Add(item);
            return true;
        }

        /// <summary>
        /// <para>Removes a Vehicle from the garage.</para>
        /// <seealso cref="GarageApplication.Classes.Garage.RemoveVehicle"/>
        /// </summary>
        public void RemoveVehicle(T item)
        {
            VehiclesInGarage.Remove(item);
        }

        /// <summary>
        /// <para>Returns a T Vehicle by regnum.</para>
        /// <seealso cref="GarageApplication.Classes.Garage.GetVehicleByREGNUM"/>
        /// </summary>
        public T GetVehicleByREGNUM(string regNum)
        {
            try
            {
                return VehiclesInGarage.Where(o => o.RegNumber == regNum).First();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in VehiclesInGarage)
            {
                yield return vehicle;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
