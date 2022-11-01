using API.Utils.ErrorMessage;
using Application.Vehicles.Update;
using Domain.Vehicles.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Vehicles.Update
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleUpdateController : ControllerBase
    {
        private readonly VehicleUpdater updater;

        public VehicleUpdateController(VehicleUpdater updater)
        {
            this.updater = updater;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPatch("{id:Guid}/number-plate")]
        public async Task<ActionResult> Update(Guid id, [FromBody] VehicleUpdateRequest request)
        {
            try
            {
                await updater.ExecuteAsync(new VehicleUpdaterRequest(id, request.NumberPlate));
                return Ok();
            }
            catch (VehicleNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
