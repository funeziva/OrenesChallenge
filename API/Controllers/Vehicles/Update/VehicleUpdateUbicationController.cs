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
    public class VehicleUpdateUbicationController : ControllerBase
    {
        private readonly VehicleUpdaterUbication updater;

        public VehicleUpdateUbicationController(VehicleUpdaterUbication updater)
        {
            this.updater = updater;
        }

        [HttpPatch("{id:Guid}/ubication")]
        public async Task<ActionResult> Update(Guid id, [FromBody] VehicleUpdateUbicationRequest request)
        {
            try
            {
                await updater.ExecuteAsync(new VehicleUpdaterUbicationRequest(id, request.Ubication));
                return Ok();
            }
            catch (VehicleNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
