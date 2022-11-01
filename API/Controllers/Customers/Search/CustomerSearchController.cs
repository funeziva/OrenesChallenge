using API.Utils.ErrorMessage;
using Application.Customers.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customers.Search
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/customers")]
    public class CustomerSearchController : ControllerBase
    {
        private readonly CustomerSearcher searcher;

        public CustomerSearchController(CustomerSearcher searcher)
        {
            this.searcher = searcher;
        }

        [ProducesResponseType(typeof(List<CustomerSearchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<CustomerSearchResponse>> Search([FromQuery] CustomerSearchRequest request)
        {
            List<CustomerSearcherResponse> customers =
                await searcher.ExecuteAsync(new CustomerSearcherRequest(request.Id, request.Name, request.TelephoneNumber, request.Address));
            return customers.ConvertAll(customer => new CustomerSearchResponse(customer.Id, customer.Name, customer.TelephoneNumber, customer.Address));
        }
    }
}
