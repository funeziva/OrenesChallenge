using API.Utils.ErrorMessage;
using Application.Customers.Delete;
using Domain.Customers.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customers.Delete
{
    
    
    [AllowAnonymous]
    [ApiController]
    [Route("api/customers")]
    public class CustomerDeleteController : ControllerBase
    {
        private readonly CustomerDeleter deleter;

        public CustomerDeleteController(CustomerDeleter deleter)
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
                await deleter.ExecuteAsync(new CustomerDeleterRequest(id));
                return Ok();
            }
            catch (CustomerNotFound exception)
            {
                return BadRequest(new ObjectResult(new ErrorMessage(exception.Message)));
            }

        }
    }
}
