using Domain.Vehicles;
using Domain.Vehicles.Predicates;


namespace Application.Vehicles.Search
{
    public class VehicleSearcher
    {
        private readonly IVehicleRepository repository;

        public VehicleSearcher(IVehicleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<VehicleSearcherResponse>> ExecuteAsync(VehicleSearcherRequest request)
        {
            List<Vehicle> vehicles = await repository.Search(new VehiclesPredicates(request.Id, request.Ubication, request.NumberPlate, request.DriverId).CreateExpression());
            return vehicles.ConvertAll(vehicle => new VehicleSearcherResponse(vehicle.Id, vehicle.Ubication, vehicle.NumberPlate, vehicle.DriverId));
        }
    }
}
