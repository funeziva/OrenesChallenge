using Application.Vehicles.Find;
using Domain.Vehicles;

namespace Application.Vehicles.Delete
{
    public class VehicleDeleter
    {
        private readonly IVehicleRepository repository;
        private readonly VehicleFinder finder;

        public VehicleDeleter(IVehicleRepository repository, VehicleFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

       

        public async Task ExecuteAsync(VehicleDeleterRequest request)
        {
            Vehicle vehicle = await finder.ExecuteAsync(new VehicleFinderRequest(request.Id));
            await repository.Delete(vehicle);
        }
    }
}
