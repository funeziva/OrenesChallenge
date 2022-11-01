using Domain.Vehicles;
using Domain.Vehicles.Exceptions;
using Domain.Vehicles.Predicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicles.Find
{
    public class VehicleFinder
    {
        private readonly IVehicleRepository repository;

        public VehicleFinder(IVehicleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Vehicle> ExecuteAsync(VehicleFinderRequest request)
        {
            Vehicle vehicle = await repository.Find(new VehiclesPredicates(request.Id, null, null, null).CreateExpression());
            
            if(vehicle == null)
            {
                throw new VehicleNotFound(request.Id);
            }

            return vehicle;
        }
    }
}
