using API.Utils.ErrorMessage;
using Application.Customers.Create;
using Domain.Customers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customers.Create
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/customers")]
    public class CustomerCreateController : ControllerBase
    {
        private readonly CustomerCreator creator;

        public CustomerCreateController(CustomerCreator creator)
        {
            this.creator = creator;
        }


        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CustomerCreateRequest request)
        {
            try
            {
                await creator.ExecuteAsync(new CustomerCreatorRequest(request.Name, request.TelephoneNumber, request.Address));

                return Created(new Uri($"{Request.Scheme}://{Request.Host.Value}/customers/{request}"), null);
            }
            catch (CustomerNameInUse exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
            catch (CustomerTelephoneNumberInUse exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }
        }
    }
}
