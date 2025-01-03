using Core.Application.Common.Commands;
using Core.Contracts.Common.Request;
using Core.Contracts.Common.Response;
using Core.Domain.Common.Entities;
using Core.Domain.Common.ValueObjects;
using Mapster;

namespace Core.Api.Common.Mapping
{
    public class CommonMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //
            // Money
            //

            config.NewConfig<MoneyRequest, CreateMoneyCommand>();

            config.NewConfig<Money, MoneyResponse>();

            //
            // Address
            //

            config.NewConfig<AddressRequest, CreateAddressCommand>();

            config.NewConfig<Address, AddressResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}