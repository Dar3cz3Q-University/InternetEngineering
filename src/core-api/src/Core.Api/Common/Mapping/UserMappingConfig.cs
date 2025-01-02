using Core.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserId, UserId>()
                .MapWith(src => src);
        }
    }
}