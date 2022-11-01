namespace API.Controllers.Vehicles.Search
{
    public record VehicleSearchRequest(Guid? Id, string? Ubication, string? NumberPlate, Guid? DriverId);
}
