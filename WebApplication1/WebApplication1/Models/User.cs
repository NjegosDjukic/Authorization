using Api.Models.Common;

namespace Api.Models;

public class User : IBaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }

}
