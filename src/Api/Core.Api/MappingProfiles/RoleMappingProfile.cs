using AutoMapper;
using Core.API.Contracts.Data.Responses;
using Core.API.Contracts.Responses;
using Core.Api.Models;

namespace Core.API.MappingProfiles.Mappers;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<Role, RoleResponseDto>();
        CreateMap<Role, RolePermissionResponseDto>()
            .ForMember(dto => dto.Permissions, opt => opt.MapFrom(r => r.Permissions.Select(p => p.Value)));
    }
}