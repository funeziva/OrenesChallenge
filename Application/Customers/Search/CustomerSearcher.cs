using Domain.Customers;
using Domain.Customers.Predicates;

namespace Application.Customers.Search
{
    public class CustomerSearcher
    {
        private readonly ICustomerRepository repository;

        public CustomerSearcher(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<CustomerSearcherResponse>> ExecuteAsync(CustomerSearcherRequest request)
        {
            List<Customer> customers = await repository.Search(new CustomersPredicates(request.Id, request.Name, request.TelephoneNumber, request.Address).CreateExpression());
            return customers.ConvertAll(customer => new CustomerSearcherResponse(customer.Id, customer.Name, customer.TelephoneNumber, customer.Address));
        }
    }
}
