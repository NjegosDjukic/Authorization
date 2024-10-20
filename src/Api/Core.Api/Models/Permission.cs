namespace Core.Api.Models;

using Core.Api.Models.Common;
using Core.Api.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Permission : IIdentity
{
    public Permission()
    {
        Roles = new Collection<Role>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public PermissionValue Value { get; set; }
    public ICollection<Role> Roles { get; set; }
}