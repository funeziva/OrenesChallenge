using API.Utils;
using API.Utils.ErrorMessage;
using Application.Users;
using Domain.Users.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Users.Login
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/users/login")]
    public class UserLoginController : ControllerBase
    {
        private readonly UserFinder finder;
        private readonly HelperJWT jwt;

        public UserLoginController(UserFinder finder, HelperJWT jwt)
        {
            this.finder = finder;
            this.jwt = jwt;
        }

        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<object>> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                UserFinderResponse user = await this.finder.ExecuteAsync(new UserFinderRequest(request.Name));
                return this.Ok(new { token = jwt.CreateToken(user.Name, user.Role) });
            }catch(UserNotFound exception)
            {
                return Unauthorized(new ObjectResult(new ErrorMessage(exception.Message)));
            }
            
        }
    }
}
