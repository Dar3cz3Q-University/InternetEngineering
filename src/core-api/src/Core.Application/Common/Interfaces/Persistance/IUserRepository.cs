using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    // TODO: [Create async repository functions #27]
    public interface IUserRepository
    {
        User? GetById(UserId id);
        User? GetByEmail(string email);
        User Add(User user);
    }
}