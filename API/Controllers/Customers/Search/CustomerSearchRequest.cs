namespace API.Controllers.Customers.Search
{
    public record CustomerSearchRequest(Guid? Id, string? Name, int? TelephoneNumber, string? Address);
}
