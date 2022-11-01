namespace Application.Customers.Update
{
    public record CustomerUpdaterRequest(Guid Id, string Name, int TelephoneNumber, string Address);
}
