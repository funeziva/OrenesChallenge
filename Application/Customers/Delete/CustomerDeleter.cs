using Application.Customers.Find;
using Domain.Customers;

namespace Application.Customers.Delete
{
    public class CustomerDeleter
    {
        private readonly ICustomerRepository repository;
        private readonly CustomerFinder finder;

        public CustomerDeleter(ICustomerRepository repository, CustomerFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(CustomerDeleterRequest request)
        {
            Customer driver = await finder.ExecuteAsync(new CustomerFinderRequest(request.Id));
            await repository.Delete(driver);
        }
    }
}
