namespace API.Controllers.Drivers.Search
{
    public record DriverSearchRequest(Guid? Id, string? Name, int? TelephoneNumber);
}
