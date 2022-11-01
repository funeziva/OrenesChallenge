namespace Domain.Customers.Exceptions
{
    public class CustomerNameInUse : Exception
    {
        public CustomerNameInUse(string name) : base($"The name {name} is in used") { }
    }
}
