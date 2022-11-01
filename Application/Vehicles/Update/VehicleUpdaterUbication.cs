using Application.Vehicles.Find;
using Domain.Vehicles;

namespace Application.Vehicles.Update
{
    public class VehicleUpdaterUbication
    {
        private readonly IVehicleRepository repository;
        private readonly VehicleFinder finder;

        public VehicleUpdaterUbication(IVehicleRepository repository, VehicleFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(VehicleUpdaterUbicationRequest request)
        {
            Vehicle vehicle = await finder.ExecuteAsync(new VehicleFinderRequest(request.Id));

            vehicle.UpdateUbication(request.Ubication);
            await repository.Update();
        }
    }
}
