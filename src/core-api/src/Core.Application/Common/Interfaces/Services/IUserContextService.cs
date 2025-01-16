using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Services
{
    public interface IUserContextService
    {
        UserId GetUserId();
    }
}