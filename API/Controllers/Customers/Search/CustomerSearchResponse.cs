namespace API.Controllers.Customers.Search
{
    public record CustomerSearchResponse(Guid Id, string Name, int TelephoneNumber, string Address);
}
