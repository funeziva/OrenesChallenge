using Application.Orders.Find;
using Domain.Orders;

namespace Application.Orders.Delete
{
    public class OrderDeleter
    {
        private readonly IOrderRepository repository;
        private readonly OrderFinder finder;

        public OrderDeleter(IOrderRepository repository, OrderFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }



        public async Task ExecuteAsync(OrderDeleterRequest request)
        {
            Order order = await finder.ExecuteAsync(new OrderFinderRequest(request.Id));
            await repository.Delete(order);
        }
    }
}
