using API.Utils.ErrorMessage;
using Application.Drivers.Create;
using Domain.Drivers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Drivers.Create
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/drivers")]
    public class DriverCreateController : ControllerBase
    {
        private readonly DriverCreator creator;

        public DriverCreateController(DriverCreator creator)
        {
            this.creator = creator;
        }


        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DriverCreateRequest request)
        {
            try
            {
                await creator.ExecuteAsync(new DriverCreatorRequest(request.Name, request.TelephoneNumber));

                return Created(new Uri($"{Request.Scheme}://{Request.Host.Value}/drivers/{request}"), null);
            }
            catch (DriverNameInUse exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
            catch(DriverTelephoneNumberInUse exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
        }
    }
}
