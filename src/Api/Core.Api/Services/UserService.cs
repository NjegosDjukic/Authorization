using AutoMapper;
using Core.Api.Contracts.Data.Responses;
using Core.Api.Contracts.Services;
using Core.Api.Data;
using Microsoft.EntityFrameworkCore;
using Core.Api.Data.Constants;
using Core.Api.Models;

namespace Core.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User currentUser;

        public UserService(ApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException();
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException();
        }

        public User GetCurrentUser()
        {
            if (currentUser != null)
            {
                return currentUser;
            }

            var identityClaim = _httpContextAccessor.HttpContext.User.FindFirst(CommonConstants.UserID);
            var id = identityClaim?.Value;

            User user;

            try
            {
                user = _dbContext.Users
                    .Include(u => u.Role)
                    .ThenInclude(r => r.Permissions)
                    .Single(x => x.FirebaseId == id);
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
            currentUser = user;

            return user;
        }

        public async Task<List<UserResponseDto>> List()
        {
            var users = await _dbContext.Users.ToListAsync();
            return _mapper.Map<List<UserResponseDto>>(users);
        }
    }
}
