using Domain.Orders;

namespace API.Controllers.Orders.Update
{
    public record OrderUpdateRequest(Guid VehicleId, OrderStatus Status);
}
