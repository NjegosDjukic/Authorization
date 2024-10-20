using Core.Api.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Core.API.Auth;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionValue Permission { get; set; }

    public PermissionRequirement(PermissionValue permission)
    {
        Permission = permission;
    }
}