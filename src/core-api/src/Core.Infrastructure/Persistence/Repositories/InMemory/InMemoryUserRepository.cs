using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.UserAggregate;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly List<User> _users = [];
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}