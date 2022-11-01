using Application.Customers.Find;
using Domain.Customers;
using Domain.Customers.Exceptions;
using Domain.Customers.Predicates;

namespace Application.Customers.Update
{
    public class CustomerUpdater
    {
        private readonly ICustomerRepository repository;
        private readonly CustomerFinder finder;

        public CustomerUpdater(ICustomerRepository repository, CustomerFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(CustomerUpdaterRequest request)
        {
            Customer customer = await finder.ExecuteAsync(new CustomerFinderRequest(request.Id));

            if (request.Name != customer.Name &&
                await repository.Any(new CustomersPredicates(null, request.Name, null, null).CreateExpression()))
            {
                throw new CustomerNameInUse(request.Name);
            }

            if (request.TelephoneNumber != customer.TelephoneNumber &&
                await repository.Any(new CustomersPredicates(null, null, request.TelephoneNumber, null).CreateExpression()))
            {
                throw new CustomerTelephoneNumberInUse(request.TelephoneNumber);
            }

            customer.Update(request.Name, request.TelephoneNumber, request.Address);
            await repository.Update();
        }
    }
}
