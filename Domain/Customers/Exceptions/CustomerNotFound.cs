namespace Domain.Customers.Exceptions
{
    public class CustomerNotFound : Exception
    {
        public CustomerNotFound(Guid id) : base($"The driver with identifier {id} is not found") { }
    }
}
