namespace API.Controllers.Vehicles.Create
{
    public record VehicleCreateRequest(string Ubication, string NumberPlate, Guid DriverId);
}
