using Domain.Drivers;
using Domain.Drivers.Predicates;

namespace Application.Drivers.Search
{
    public class DriverSearcher
    {
        private readonly IDriverRepository repository;

        public DriverSearcher(IDriverRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<DriverSearcherResponse>> ExecuteAsync(DriverSearcherRequest request)
        {
            List<Driver> drivers = await repository.Search(new DriversPredicates(request.Id, request.Name, request.TelephoneNumber).CreateExpression());
            return drivers.ConvertAll(driver => new DriverSearcherResponse(driver.Id, driver.Name, driver.TelephoneNumber));
        }
    }
}
