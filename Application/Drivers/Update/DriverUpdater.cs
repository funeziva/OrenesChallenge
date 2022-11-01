using Application.Drivers.Find;
using Domain.Drivers;
using Domain.Drivers.Exceptions;
using Domain.Drivers.Predicates;

namespace Application.Drivers.Update
{
    public class DriverUpdater
    {
        private readonly IDriverRepository repository;
        private readonly DriverFinder finder;

        public DriverUpdater(IDriverRepository repository, DriverFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(DriverUpdaterRequest request)
        {
            Driver driver = await finder.ExecuteAsync(new DriverFinderRequest(request.Id));

            if (request.Name != driver.Name &&
                await repository.Any(new DriversPredicates(null, request.Name, null).CreateExpression()))
            {
                throw new DriverNameInUse(request.Name);
            }

            if (request.TelephoneNumber != driver.TelephoneNumber &&
                await repository.Any(new DriversPredicates(null, null, request.TelephoneNumber).CreateExpression()))
            {
                throw new DriverTelephoneNumberInUse(request.TelephoneNumber);
            }

            driver.Update(request.Name, request.TelephoneNumber);
            await repository.Update();
        }
    }
}
