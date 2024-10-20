using Core.Api.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("v1/[controller]")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService ?? throw new ArgumentNullException();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult>List()
        {
            var users = await _userService.List();
            return Ok(users);

        }

    }
}
