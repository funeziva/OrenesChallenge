using API.Utils.ErrorMessage;
using Application.Orders.Delete;
using Domain.Orders.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Orders.Delete
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/orders")]
    public class OrderDeleteController : ControllerBase
    {
        private readonly OrderDeleter deleter;

        public OrderDeleteController(OrderDeleter deleter)
        {
            this.deleter = deleter;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await deleter.ExecuteAsync(new OrderDeleterRequest(id));
                return Ok();
            }
            catch (OrderNotFound exception)
            {
                return BadRequest(new ErrorMessage(exception.Message));
            }

        }
    }
}
