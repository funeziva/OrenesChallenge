namespace Application.Vehicles.Search
{
    public record VehicleSearcherResponse(Guid? Id, string? Ubication, string? NumberPlate, Guid? DriverId);
}