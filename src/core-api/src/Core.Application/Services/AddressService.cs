using Core.Application.Common.Commands;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.Common.Entities;

namespace Core.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IGeocodingService _geocodingService;

        public async Task<Address> CreateAddressAsync(CreateAddressCommand command)
        {
            double? latitude = command.Latitude;
            double? longitude = command.Longitude;

            if (latitude is null || longitude is null)
            {
                try
                {
                    // TODO: Get latitude and longitude from external API
                    latitude = 10.5;
                    longitude = 10.5;
                }
                catch
                {
                    // TODO: Throw domain error
                }
            }

            return Address.Create(
                command.Street,
                command.BuildingNumber,
                command.ApartmentNumber,
                command.PostalCode,
                command.City,
                command.State,
                command.Country,
                latitude!.Value,
                longitude!.Value);
        }
    }
}