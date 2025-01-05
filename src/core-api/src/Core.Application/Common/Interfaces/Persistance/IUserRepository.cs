using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        Task<ErrorOr<Created>> AddAsync(User user);
        Task<ErrorOr<User>> GetByEmailAsync(string email);
        Task<ErrorOr<User>> GetByIdAsync(UserId id);
    }
}