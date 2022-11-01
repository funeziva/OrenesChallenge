using API.Utils.ErrorMessage;
using Application.Drivers.Delete;
using Domain.Drivers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Drivers.Delete
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/drivers")]
    public class DriverDeleteController : ControllerBase
    {
        private readonly DriverDeleter deleter;

        public DriverDeleteController(DriverDeleter deleter)
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
                await deleter.ExecuteAsync(new DriverDeleterRequest(id));
                return Ok();
            }
            catch (DriverNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
