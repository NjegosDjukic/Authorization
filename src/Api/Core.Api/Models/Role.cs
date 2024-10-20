namespace Core.API.Models;

using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Role
{
    public Role()
    {
        Permissions = new Collection<Permission>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Permission> Permissions { get; set; }
}