using AutoMapper;
using Core.Api.Contracts.Data.Responses;
using Core.Api.Models;

namespace Core.Api.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile() 
    {
        CreateMap<User, UserResponseDto>();
    }
}
