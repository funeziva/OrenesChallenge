using API.Utils.ErrorMessage;
using Application.Orders.Search;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Orders.Search
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Customer")]
    [ApiController]
    [Route("api/orders")]
    public class OrderSearchController : ControllerBase
    {
        private readonly OrderSearcher searcher;

        public OrderSearchController(OrderSearcher searcher)
        {
            this.searcher = searcher;
        }

        [ProducesResponseType(typeof(List<OrderSearchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<List<OrderSearchResponse>> Search([FromQuery] OrderSearchRequest request)
        {
            List<OrderSearcherResponse> orders =
                await searcher.ExecuteAsync(new OrderSearcherRequest(request.Id, request.VehicleId, request.CustomerId, request.Status));
            return orders.ConvertAll(order => new OrderSearchResponse(order.Id, order.VehicleId, order.CustomerId, order.Status));
        }
    }
}
