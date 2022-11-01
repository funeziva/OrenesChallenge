namespace Domain.Customers.Exceptions
{
    public class CustomerTelephoneNumberInUse : Exception
    {
        public CustomerTelephoneNumberInUse(int telephoneNumber) : base($"The telephone number {telephoneNumber} is in used") { }
    }
}
