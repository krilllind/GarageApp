using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Classes
{
    class Airplane : Vehicle
    {
        public Airplane(string name, string regnum, string color, int numberoftires, int modelyear, bool needlicens = true) 
                : base(name, regnum, color, numberoftires, modelyear, needlicens) {}
    }
}
