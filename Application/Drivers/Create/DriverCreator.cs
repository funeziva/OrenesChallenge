using Domain.Drivers;
using Domain.Drivers.Exceptions;
using Domain.Drivers.Predicates;

namespace Application.Drivers.Create
{
    public class DriverCreator
    {
        private readonly IDriverRepository repository;

        public DriverCreator(IDriverRepository repository)
        {
            this.repository = repository;
        }

        public async Task ExecuteAsync(DriverCreatorRequest request)
        {
            if(await repository.Any(new DriversPredicates(null, request.Name, null).CreateExpression()))
            {
                throw new DriverNameInUse(request.Name);
            }

            if (await repository.Any(new DriversPredicates(null, null, request.TelephoneNumber).CreateExpression()))
            {
                throw new DriverTelephoneNumberInUse(request.TelephoneNumber);
            }

            Driver driver = Driver.Create(request.Name, request.TelephoneNumber);
            await repository.Create(driver);
        }
    }
}
