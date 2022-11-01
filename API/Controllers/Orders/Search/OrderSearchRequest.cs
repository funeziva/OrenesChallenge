using Domain.Orders;

namespace API.Controllers.Orders.Search
{
    public record OrderSearchRequest(Guid? Id, Guid? VehicleId, Guid? CustomerId, OrderStatus? Status);
}
