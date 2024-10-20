namespace Core.API.Models;

using Core.API.Models;
using Core.Api.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Permission
{
    public Permission()
    {
        Roles = new Collection<Role>();
    }

    public int Id { get; set; }
    public PermissionValue Value { get; set; }
    public ICollection<Role> Roles { get; set; }
}