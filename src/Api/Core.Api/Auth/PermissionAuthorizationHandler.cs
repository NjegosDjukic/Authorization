using Core.Api.Data;
using Core.API.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace Core.API.Auth;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly ApplicationDbContext _dbContext;

    public PermissionAuthorizationHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null)
        {
            context.Fail();
            return;
        }

        var claimFirebaseId = context.User.Claims.FirstOrDefault(c => c.Type == CommonConstants.UserID)?.Value;

        if (claimFirebaseId != null)
        {
            var roleId = _dbContext.Users.FirstOrDefault(x => x.FirebaseId == claimFirebaseId)?.RoleId;
            var role = await _dbContext.Roles.Include(x => x.Permissions).SingleAsync(x => x.Id == roleId);

            if (role != null && role.Permissions.Any(permission => permission.Value.Equals(requirement.Permission)))
            {
                context.Succeed(requirement);
                return;
            }
        }

        context.Fail();
    }
}