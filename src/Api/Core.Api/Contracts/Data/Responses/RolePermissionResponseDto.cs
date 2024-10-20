using Core.Api.Models.Enums;
using Core.API.Contracts.Responses;

namespace Core.API.Contracts.Data.Responses;

public record RolePermissionResponseDto : RoleResponseDto
{
    public IEnumerable<PermissionValue> Permissions { get; set; }
}