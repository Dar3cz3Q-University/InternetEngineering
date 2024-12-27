using Core.Application.Authentication.Commands.RegisterCommand;
using Core.Application.Authentication.Common;
using Core.Application.Authentication.Queries.LoginQuery;
using Core.Contracts.Authentication.Request;
using Core.Contracts.Authentication.Response;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}