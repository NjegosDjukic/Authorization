using AutoMapper;
using Core.Api.Contracts.Data.Responses;
using Core.Api.Contracts.Services;
using Core.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(ApplicationDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public async Task<List<UserResponseDto>> List()
        {
            var users = await _dbContext.Users.ToListAsync();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

    }
}
