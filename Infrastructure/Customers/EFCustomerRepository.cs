using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Customers
{
    public class EFCustomerRepository : ICustomerRepository
    {

        private readonly ApplicationContext context;

        public EFCustomerRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> Any(Expression<Func<Customer, bool>> expression)
        {
            Customer customer = await context.Customers.FirstOrDefaultAsync(expression);
            return customer != null;
        }

        public async Task Create(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task<Customer> Find(Expression<Func<Customer, bool>> expression)
        {
            return await context.Customers.FirstOrDefaultAsync(expression);
        }

        public async Task<List<Customer>> Search(Expression<Func<Customer, bool>> expression)
        {
            return await context.Customers.AsQueryable().Where(expression).ToListAsync();
        }

        public async Task Update()
        {
            await context.SaveChangesAsync();
        }
    }
}
