using Application.Customers.Search;
using Application.Drivers.Search;
using Domain.Users.Exceptions;

namespace Application.Users
{
    public class UserFinder
    {
        private readonly DriverSearcher driverSearcher;
        private readonly CustomerSearcher customerSearcher;

        public UserFinder(DriverSearcher driverSearcher, CustomerSearcher customerSearcher)
        {
            this.driverSearcher = driverSearcher;
            this.customerSearcher = customerSearcher;
        }

        public async Task<UserFinderResponse> ExecuteAsync(UserFinderRequest request)
        {
            List<DriverSearcherResponse> drivers = await driverSearcher.ExecuteAsync(new DriverSearcherRequest(null, null, null));

            if(drivers.Any(x => x.Name == request.Name))
            {
                return new UserFinderResponse(request.Name, "Driver");
            }

            List<CustomerSearcherResponse> customers = await customerSearcher.ExecuteAsync(new CustomerSearcherRequest(null, null, null, null));

            if (customers.Any(x => x.Name == request.Name))
            {
                return new UserFinderResponse(request.Name, "Customer");
            }

            throw new UserNotFound(request.Name);
        }
    }
}
