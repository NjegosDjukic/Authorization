using Core.Api.Contracts.Services;
using Core.Api.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("v1/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService ?? throw new ArgumentNullException();
        }

        [Authorize(nameof(PermissionValue.ListUsers))]
        [HttpGet]
        public async Task<IActionResult>List()
        {
            var users = await _userService.List();
            return Ok(users);

        }

    }
}
