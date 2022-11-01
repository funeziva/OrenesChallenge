using Domain.Customers;
using Domain.Customers.Exceptions;
using Domain.Customers.Predicates;

namespace Application.Customers.Find
{
    public class CustomerFinder
    {
        private readonly ICustomerRepository repository;

        public CustomerFinder(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Customer> ExecuteAsync(CustomerFinderRequest request)
        {
            Customer customer = await repository.Find(new CustomersPredicates(request.Id, null, null, null).CreateExpression());

            if (customer == null)
            {
                throw new CustomerNotFound(request.Id);
            }

            return customer;
        }
    }
}
