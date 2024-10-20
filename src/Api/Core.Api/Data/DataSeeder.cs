using Core.Api.Models.Enums;
using Core.API.Common.Constants;
using Core.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Api.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DataSeeder (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            var userPermissions = new List<Permission>();
            var adminPermissions = new List<Permission>();

            foreach (var permissionEnum in (PermissionValue[])Enum.GetValues(typeof(PermissionValue)))
            {
                var permission = new Permission
                {
                    Id = (int)permissionEnum,
                    Value = permissionEnum
                };

                if (!_dbContext.Permissions.Any(p => p.Id == permission.Id))
                {
                    _dbContext.Permissions.Add(permission);
                }

                adminPermissions.Add(permission);

                switch (permissionEnum)
                {
                    case PermissionValue.ListUsers:
                        userPermissions.Add(permission);
                        break;
                }

                _dbContext.SaveChanges();

                var adminRole = _dbContext.Roles.Include(x => x.Permissions).SingleOrDefault(x => x.Name == MainRoles.Admin);

                if (adminRole == null)
                {
                    adminRole = new Role
                    {
                        Id = 1,
                        Name = MainRoles.Admin
                    };

                    _dbContext.Roles.Add(adminRole);
                    _dbContext.SaveChanges();
                }

                var userRole = _dbContext.Roles.Include(x => x.Permissions).SingleOrDefault(x => x.Name == MainRoles.RegularUser);
                if (userRole == null)
                {
                    userRole = new Role
                    {
                        Id = 2,
                        Name = MainRoles.RegularUser
                    };

                    _dbContext.Roles.Add(userRole);
                    _dbContext.SaveChanges();

                }
                AddPermissionsToRole(adminRole, adminPermissions);
                AddPermissionsToRole(userRole, userPermissions);

                _dbContext.SaveChanges();
            }
        }
        private void AddPermissionsToRole(Role role, IEnumerable<Permission> permissions)
        {
            foreach (var permission in permissions)
            {
                if (role.Permissions.Any(x => x.Id == permission.Id))
                {
                    continue;
                }

                var permissionData = _dbContext.Permissions.Single(x => x.Value == permission.Value);
                permissionData.Roles.Add(role);
                role.Permissions.Add(permissionData);
            }

            _dbContext.Update(role);
        }
    }
}
