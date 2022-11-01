using API.Utils.ErrorMessage;
using Application.Orders.Update;
using Domain.Orders.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Orders.Update
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/orders")]
    public class OrderUpdateController : ControllerBase
    {
        private readonly OrderUpdater updater;

        public OrderUpdateController(OrderUpdater updater)
        {
            this.updater = updater;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPatch("{id:Guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] OrderUpdateRequest request)
        {
            try
            {
                await updater.ExecuteAsync(new OrderUpdaterRequest(id, request.VehicleId, request.Status));
                return Ok();
            }
            catch (OrderNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
            catch (OrderStatusBadUse exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
