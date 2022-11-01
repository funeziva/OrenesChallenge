using API.Utils.ErrorMessage;
using Application.Drivers.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Drivers.Search
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/drivers")]
    public class DriverSearchController : ControllerBase
    {
        private readonly DriverSearcher searcher;

        public DriverSearchController(DriverSearcher searcher)
        {
            this.searcher = searcher;
        }

        [ProducesResponseType(typeof(List<DriverSearchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<DriverSearchResponse>> Search([FromQuery] DriverSearchRequest request)
        {
            List<DriverSearcherResponse> vehicles =
                await searcher.ExecuteAsync(new DriverSearcherRequest(request.Id, request.Name, request.TelephoneNumber));
            return vehicles.ConvertAll(driver => new DriverSearchResponse(driver.Id, driver.Name, driver.TelephoneNumber));
        }
    }
}
