namespace Core.Api.Models;

using Core.Api.Models.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Role : IIdentity
{
    public Role()
    {
        Permissions = new Collection<Permission>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Permission> Permissions { get; set; }
}