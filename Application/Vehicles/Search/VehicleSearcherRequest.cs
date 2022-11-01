namespace Application.Vehicles.Search
{
    public record VehicleSearcherRequest(Guid? Id, string? Ubication, string? NumberPlate, Guid? DriverId);
}
