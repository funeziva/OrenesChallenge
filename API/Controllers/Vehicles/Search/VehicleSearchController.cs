using API.Utils.ErrorMessage;
using Application.Vehicles.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Vehicles.Search
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleSearchController : ControllerBase
    {
        private readonly VehicleSearcher searcher;
        
        public VehicleSearchController(VehicleSearcher searcher)
        {
            this.searcher = searcher;
        }

        [ProducesResponseType(typeof(List<VehicleSearchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<VehicleSearchResponse>> Search([FromQuery] VehicleSearchRequest request)
        {
            List<VehicleSearcherResponse> vehicles = 
                await searcher.ExecuteAsync(new VehicleSearcherRequest(request.Id, request.Ubication, request.NumberPlate, request.DriverId));
            return vehicles.ConvertAll(vehicle => new VehicleSearchResponse(vehicle.Id, vehicle.Ubication, vehicle.NumberPlate, vehicle.DriverId));
        }
    }
}
