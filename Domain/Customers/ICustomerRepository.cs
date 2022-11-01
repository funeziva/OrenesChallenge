using System.Linq.Expressions;

namespace Domain.Customers
{
    public interface ICustomerRepository
    {
        Task Create(Customer customer);
        Task Update();
        Task<bool> Any(Expression<Func<Customer, bool>> expression);
        Task<Customer> Find(Expression<Func<Customer, bool>> expression);
        Task Delete(Customer customer);
        Task<List<Customer>> Search(Expression<Func<Customer, bool>> expression);
    }
}
