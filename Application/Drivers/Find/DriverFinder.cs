using Domain.Drivers;
using Domain.Drivers.Exceptions;
using Domain.Drivers.Predicates;

namespace Application.Drivers.Find
{
    public class DriverFinder
    {
        private readonly IDriverRepository repository;

        public DriverFinder(IDriverRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Driver> ExecuteAsync(DriverFinderRequest request)
        {
            Driver driver = await repository.Find(new DriversPredicates(request.Id, null, null).CreateExpression());

            if (driver == null)
            {
                throw new DriverNotFound(request.Id);
            }

            return driver;
        }
    }
}
