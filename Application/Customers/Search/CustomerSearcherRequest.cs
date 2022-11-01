namespace Application.Customers.Search
{
    public record CustomerSearcherRequest(Guid? Id, string? Name, int? TelephoneNumber, string? Address);
}
