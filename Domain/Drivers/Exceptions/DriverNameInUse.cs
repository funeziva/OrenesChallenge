using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Drivers.Exceptions
{
    public class DriverNameInUse : Exception
    {
        public DriverNameInUse(string name) : base($"The name {name} is in used") { }
    }
}
