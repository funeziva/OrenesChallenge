using System.Linq.Expressions;

namespace Domain.Orders
{
    public interface IOrderRepository
    {
        Task Create(Order order);
        Task Update();
        Task<Order> Find(Expression<Func<Order, bool>> expression);
        Task Delete(Order order);
        Task<List<Order>> Search(Expression<Func<Order, bool>> expression);
    }
}
