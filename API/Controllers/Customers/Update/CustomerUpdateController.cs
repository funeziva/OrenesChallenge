using API.Utils.ErrorMessage;
using Application.Customers.Update;
using Domain.Customers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customers.Update
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/customers")]
    public class CustomerUpdateController : ControllerBase
    {
        private readonly CustomerUpdater updater;

        public CustomerUpdateController(CustomerUpdater updater)
        {
            this.updater = updater;
        }

        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] CustomerUpdateRequest request)
        {
            try
            {
                await updater.ExecuteAsync(new CustomerUpdaterRequest(id, request.Name, request.TelephoneNumber, request.Address));
                return Ok();
            }
            catch (CustomerNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
