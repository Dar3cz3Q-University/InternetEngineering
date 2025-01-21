using Core.Contracts.Authentication.Response;
using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ImageUrl, src => $"http://maselniczka:8080/{src.ImageUrl}")
                .Map(dest => dest, src => src);

            config.NewConfig<UserId, UserId>()
                .MapWith(src => src);
        }
    }
}