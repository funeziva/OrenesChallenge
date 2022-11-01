namespace API.Controllers.Customers.Update
{
    public record CustomerUpdateRequest(string Name, int TelephoneNumber, string Address);
}
