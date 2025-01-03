using Core.Application.Common.Commands;
using Core.Domain.Common.Entities;

namespace Core.Application.Common.Interfaces.Services
{
    public interface IAddressService
    {
        Task<Address> CreateAddressAsync(CreateAddressCommand command);
    }
}