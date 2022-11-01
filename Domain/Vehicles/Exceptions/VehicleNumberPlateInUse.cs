using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vehicles.Exceptions
{
    public class VehicleNumberPlateInUse : Exception
    {
        public VehicleNumberPlateInUse(string numberPlate) : base($"The number plate {numberPlate} is in used") { }
    }
}
