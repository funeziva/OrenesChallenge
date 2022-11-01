using Application.Drivers.Find;
using Domain.Drivers;
using Domain.Vehicles;
using Domain.Vehicles.Exceptions;
using Domain.Vehicles.Predicates;

namespace Application.Vehicles.Create
{
    public class VehicleCreator
    {
        private readonly IVehicleRepository repository;
        private readonly DriverFinder finder;

        public VehicleCreator(IVehicleRepository repository, DriverFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(VehicleCreatorRequest request)
        {
            _ = await finder.ExecuteAsync(new DriverFinderRequest(request.DriverId));

            if(await repository.Any(new VehiclesPredicates(null, null, request.NumberPlate, null).CreateExpression()))
            {
                throw new VehicleNumberPlateInUse(request.NumberPlate);
            }



            Vehicle vehicle = Vehicle.Create(request.Ubication, request.NumberPlate, request.DriverId);
            await repository.Create(vehicle);
        }
    }
}
