using AutoMapper;
using Core.Api.Contracts.Data.Responses;
using Core.Api.Contracts.Services;
using Core.Api.Models.Enums;
using Core.Api.Services;
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
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper) 
        {
            _userService = userService ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpGet("current-user")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        public ActionResult<UserResponseDto> GetCurrentUser()
        {
            return Ok(_mapper.Map<UserResponseDto>(_userService.GetCurrentUser()));
        }

        [Authorize(nameof(PermissionValue.CreateUser))]
        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult>List()
        {
            var users = await _userService.List();
            return Ok(_mapper.Map<List<UserResponseDto>>(users));

        }

    }
}
