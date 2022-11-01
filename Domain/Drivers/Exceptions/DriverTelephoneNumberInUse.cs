using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Drivers.Exceptions
{
    public class DriverTelephoneNumberInUse : Exception
    {
        public DriverTelephoneNumberInUse(int telephoneNumber) : base($"The telephone number {telephoneNumber} is in used") { }
    }
}
