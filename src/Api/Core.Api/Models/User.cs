﻿using Core.Api.Models.Common;
using Core.Api.Models.Enums;

namespace Core.Api.Models;

public class User : IBaseEntity
{

 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string FirebaseId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Role Role { get; set; }
}
