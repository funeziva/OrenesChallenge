namespace Domain.Orders.Exceptions
{
    public class OrderStatusBadUse : Exception
    {
        public OrderStatusBadUse() : base($"This status does not exist") { }
    }
}
