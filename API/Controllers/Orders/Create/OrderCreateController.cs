using API.Utils.ErrorMessage;
using Application.Orders.Create;
using Domain.Customers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Orders.Create
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/orders")]
    public class OrderCreateController : ControllerBase
    {
        private readonly OrderCreator creator;


        public OrderCreateController(OrderCreator creator)
        {
            this.creator = creator;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderCreateRequest request)
        {
            try
            {
                await creator.ExecuteAsync(new OrderCreatorRequest(request.CustomerId));

                return Created(new Uri($"{Request.Scheme}://{Request.Host.Value}/orders/{request}"), null);
            }
            catch (CustomerNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
        }
    }
}
