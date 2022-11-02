using Domain.Orders;

namespace API.Controllers.Orders.Search
{
    public record OrderSearchResponse(Guid Id, Guid? VehicleId, Guid CustomerId, OrderStatus Status);
}
