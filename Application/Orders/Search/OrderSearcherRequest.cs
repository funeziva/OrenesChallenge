using Domain.Orders;

namespace Application.Orders.Search
{
    public record OrderSearcherRequest(Guid? Id, Guid? VehicleId, Guid? CustomerId, OrderStatus? Status);
}
