using Core.Api.Contracts.Data.Responses;
using Core.Api.Models;

namespace Core.Api.Contracts.Services;

public interface IUserService
{
    Task<List<UserResponseDto>> List();
}
