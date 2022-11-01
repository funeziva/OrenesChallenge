using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Drivers.Exceptions
{
    public class DriverNotFound : Exception
    {
        public DriverNotFound(Guid id) : base($"The driver with identifier {id} is not found") { }
    }
}
