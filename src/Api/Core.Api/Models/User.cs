using Core.Api.Models.Common;

namespace Core.Api.Models;

public class User : IBaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string FirebaseId { get; set; }
    public bool IsSuperAdmin { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
