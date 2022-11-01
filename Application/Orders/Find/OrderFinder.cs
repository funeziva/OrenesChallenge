using Domain.Orders;
using Domain.Orders.Exceptions;
using Domain.Orders.Predicates;

namespace Application.Orders.Find
{
    public class OrderFinder
    {
        private readonly IOrderRepository repository;

        public OrderFinder(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Order> ExecuteAsync(OrderFinderRequest request)
        {
            Order order = await repository.Find(new OrdersPredicates(request.Id, null, null, null).CreateExpression());

            if (order == null)
            {
                throw new OrderNotFound(request.Id);
            }

            return order;
        }
    }
}
