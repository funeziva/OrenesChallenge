using API.Utils.ErrorMessage;
using Application.Vehicles.Create;
using Domain.Drivers.Exceptions;
using Domain.Vehicles.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Vehicles.Create
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Driver")]
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleCreateController : ControllerBase
    {
        private readonly VehicleCreator creator;

        
        public VehicleCreateController(VehicleCreator creator)
        {
            this.creator = creator;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VehicleCreateRequest request)
        {
            try
            {
                await creator.ExecuteAsync(new VehicleCreatorRequest(request.Ubication, request.NumberPlate, request.DriverId));

                return Created(new Uri($"{Request.Scheme}://{Request.Host.Value}/vehicles/{request}"), null);
            }
            catch(VehicleNumberPlateInUse exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
            catch(DriverNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
        }
    }
}
