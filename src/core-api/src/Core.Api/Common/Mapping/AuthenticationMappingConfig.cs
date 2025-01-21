using Core.Application.Authentication.Commands.Register;
using Core.Application.Authentication.Common;
using Core.Application.Authentication.Queries.Login;
using Core.Contracts.Authentication.Request;
using Core.Contracts.Authentication.Response;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //
            // Response
            //

            config.NewConfig<AuthenticationDTO, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest.ImageUrl, src => $"http://maselniczka:8080/{src.User.ImageUrl}")
                .Map(dest => dest, src => src.User);

            //
            // Register
            //

            config.NewConfig<RegisterRequest, RegisterCommand>();

            //
            // Login
            //

            config.NewConfig<LoginRequest, LoginQuery>();
        }
    }
}