using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly List<User> _users = [];

        public User? GetById(UserId id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public User? GetByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
        public User Add(User user)
        {
            _users.Add(user);
            return user;
        }
    }
}