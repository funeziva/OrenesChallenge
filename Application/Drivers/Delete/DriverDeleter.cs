using Application.Drivers.Find;
using Domain.Drivers;

namespace Application.Drivers.Delete
{
    public class DriverDeleter
    {
        private readonly IDriverRepository repository;
        private readonly DriverFinder finder;

        public DriverDeleter(IDriverRepository repository, DriverFinder finder)
        {
            this.repository = repository;
            this.finder = finder;
        }

        public async Task ExecuteAsync(DriverDeleterRequest request)
        {
            Driver driver = await finder.ExecuteAsync(new DriverFinderRequest(request.Id));
            await repository.Delete(driver);
        }
    }
}
