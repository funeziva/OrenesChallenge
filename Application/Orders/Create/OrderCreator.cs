using Application.Customers.Find;
using Domain.Orders;

namespace Application.Orders.Create
{
    public class OrderCreator
    {
        private readonly IOrderRepository repository;
        private readonly CustomerFinder finder;

        public OrderCreator(IOrderRepository repository, CustomerFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(OrderCreatorRequest request)
        {
            _ = await finder.ExecuteAsync(new CustomerFinderRequest(request.CustomerId));

            Order vehicle = Order.Create(request.CustomerId);
            await repository.Create(vehicle);
        }
    }
}
