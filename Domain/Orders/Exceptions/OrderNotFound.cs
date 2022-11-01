namespace Domain.Orders.Exceptions
{
    public class OrderNotFound : Exception
    {
        public OrderNotFound(Guid id) : base($"The order with identifier {id} is not found") { }
    }
}
