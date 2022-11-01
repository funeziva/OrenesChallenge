using Domain.Orders;

namespace Application.Orders.Update
{
    public record OrderUpdaterRequest(Guid Id, Guid VehicleId, OrderStatus Status);
}
