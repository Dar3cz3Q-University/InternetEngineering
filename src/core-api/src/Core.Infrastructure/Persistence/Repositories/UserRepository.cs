using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainDbContext _dbContext;

        public UserRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<Created>> AddAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<User>> GetByEmailAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user is null)
                return Errors.User.NotFoundByEmail(email);

            return user;
        }

        public async Task<ErrorOr<User>> GetByIdAsync(UserId id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user is null)
                return Errors.User.NotFound(id);

            return user;
        }
    }
}