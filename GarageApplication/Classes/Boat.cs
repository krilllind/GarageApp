using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes
{
    class Boat : Vehicle
    {
        public Boat(string name, string regnum, string color, int numberoftires, int modelyear, bool needlicens = true) 
                : base(name, regnum, color, numberoftires, modelyear, needlicens) {}
    }
}
