using API.Utils.ErrorMessage;
using Application.Drivers.Update;
using Domain.Drivers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Drivers.Update
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/drivers")]
    public class DriverUpdateController : ControllerBase
    {
        private readonly DriverUpdater updater;

        public DriverUpdateController(DriverUpdater updater)
        {
            this.updater = updater;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] DriverUpdateRequest request)
        {
            try
            {
                await updater.ExecuteAsync(new DriverUpdaterRequest(id, request.Name, request.TelephoneNumber));
                return Ok();
            }
            catch (DriverNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
