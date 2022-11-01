using Domain.Orders;
using Domain.Orders.Predicates;

namespace Application.Orders.Search
{
    public class OrderSearcher
    {
        private readonly IOrderRepository repository;

        public OrderSearcher(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<OrderSearcherResponse>> ExecuteAsync(OrderSearcherRequest request)
        {
            List<Order> orders = await repository.Search(new OrdersPredicates(request.Id, request.VehicleId, request.CustomerId, request.Status).CreateExpression());
            return orders.ConvertAll(order => new OrderSearcherResponse(order.Id, order.VehicleId, order.CustomerId, order.Status, order.Vehicle.Ubication));
        }
    }
}
