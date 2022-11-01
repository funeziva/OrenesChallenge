using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Orders
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationContext context;

        public EFOrderRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> Any(Expression<Func<Order, bool>> expression)
        {
            Order order = await context.Orders.FirstOrDefaultAsync(expression);
            return order != null;
        }

        public async Task Create(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task<Order> Find(Expression<Func<Order, bool>> expression)
        {
            return await context.Orders.FirstOrDefaultAsync(expression);
        }

        public async Task<List<Order>> Search(Expression<Func<Order, bool>> expression)
        {
            return await context.Orders.AsQueryable().Where(expression).ToListAsync();
        }

        public async Task Update()
        {
            await context.SaveChangesAsync();
        }
    }
}
