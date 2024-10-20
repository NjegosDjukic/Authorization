using Core.Api.Models;
using Core.API.Contracts.Data.Responses;
using Core.API.Contracts.Responses;

namespace Core.Api.Contracts.Data.Responses
{
    public record UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string FirebaseId { get; set; }
        public RolePermissionResponseDto Role { get; set; }
    }
}
