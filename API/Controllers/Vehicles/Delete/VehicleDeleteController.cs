using API.Utils.ErrorMessage;
using Application.Vehicles.Delete;
using Domain.Vehicles.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Vehicles.Delete
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Driver")]
    [AllowAnonymous]
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleDeleteController : ControllerBase
    {
        private readonly VehicleDeleter deleter;

        public VehicleDeleteController(VehicleDeleter deleter)
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
                await deleter.ExecuteAsync(new VehicleDeleterRequest(id));
                return Ok();
            }
            catch (VehicleNotFound exception)
            {
                return BadRequest(new ErrorMessage(exception.Message));
            }
            
        }
    }
}
