using Domain.Customers;
using Domain.Customers.Exceptions;
using Domain.Customers.Predicates;

namespace Application.Customers.Create
{
    public class CustomerCreator
    {
        private readonly ICustomerRepository repository;

        public CustomerCreator(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(CustomerCreatorRequest request)
        {
            if (await repository.Any(new CustomersPredicates(null, request.Name, null, null).CreateExpression()))
            {
                throw new CustomerNameInUse(request.Name);
            }

            if (await repository.Any(new CustomersPredicates(null, null, request.TelephoneNumber, null).CreateExpression()))
            {
                throw new CustomerTelephoneNumberInUse(request.TelephoneNumber);
            }

            Customer customer = Customer.Create(request.Name, request.TelephoneNumber, request.Address);
            await repository.Create(customer);
        }
    }
}
