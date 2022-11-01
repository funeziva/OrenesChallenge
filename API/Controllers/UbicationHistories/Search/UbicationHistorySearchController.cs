using API.Utils.ErrorMessage;
using Application.UbicationHistories.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UbicationHistories.Search
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/ubications")]
    public class UbicationHistorySearchController : ControllerBase
    {
        private readonly UbicationHistorySearcher searcher;

        public UbicationHistorySearchController(UbicationHistorySearcher searcher)
        {
            this.searcher = searcher;
        }

        [ProducesResponseType(typeof(List<UbicationHistorySearchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<UbicationHistorySearchResponse>> Search([FromQuery] UbicationHistorySearchRequest request)
        {
            List<UbicationHistorySearcherResponse> ubications =
                await searcher.ExecuteAsync(new UbicationHistorySearcherRequest(request.VehicleId, request.CretedDate));
            return ubications.ConvertAll(ubication => new UbicationHistorySearchResponse(ubication.VehicleId, ubication.Ubication, ubication.CretedDate));
        }
    }
}
