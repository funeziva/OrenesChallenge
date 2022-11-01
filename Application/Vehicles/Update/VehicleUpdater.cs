using Application.Vehicles.Find;
using Domain.Vehicles;
using Domain.Vehicles.Exceptions;
using Domain.Vehicles.Predicates;

namespace Application.Vehicles.Update
{
    public class VehicleUpdater
    {
        private readonly IVehicleRepository repository;
        private readonly VehicleFinder finder;

        public VehicleUpdater(IVehicleRepository repository, VehicleFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(VehicleUpdaterRequest request)
        {
            Vehicle vehicle = await finder.ExecuteAsync(new VehicleFinderRequest(request.Id));

            if(request.NumberPlate != vehicle.NumberPlate &&
                await repository.Any(new VehiclesPredicates(null, null, request.NumberPlate, null).CreateExpression()))
            {
                throw new VehicleNumberPlateInUse(request.NumberPlate);
            }

            vehicle.UpdateNumberPlate(request.NumberPlate);
            await repository.Update();
        }
    }
}
