using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Drivers.Update
{
    public record DriverUpdaterRequest(Guid Id, string Name, int TelephoneNumber);
}
