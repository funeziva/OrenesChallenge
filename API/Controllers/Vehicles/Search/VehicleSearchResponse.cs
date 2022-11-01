namespace API.Controllers.Vehicles.Search
{
    public record VehicleSearchResponse(Guid? Id, string? Ubication, string? NumberPlate, Guid? DriverId);
}
