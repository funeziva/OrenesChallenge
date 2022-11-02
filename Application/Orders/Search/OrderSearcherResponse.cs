using Domain.Orders;

namespace Application.Orders.Search
{
    public record OrderSearcherResponse(Guid Id, Guid? VehicleId, Guid CustomerId, OrderStatus Status);
}
