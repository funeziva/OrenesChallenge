namespace API.Controllers.Customers.Create
{
    public record CustomerCreateRequest(string Name, int TelephoneNumber, string Address);
}
