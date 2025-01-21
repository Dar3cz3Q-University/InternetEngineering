using Core.Domain.Common.Entities;
using Core.Domain.Common.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IAddressRepository
    {
        Task<ErrorOr<Created>> AddAsync(Address address);
        Task<ErrorOr<Deleted>> DeleteByIdAsync(AddressId id);
        Task<ErrorOr<Address>> GetByIdAsync(AddressId id);
        Task<ErrorOr<List<Address>>> GetByIdsAsync(List<AddressId> ids);
        Task<ErrorOr<List<Address>>> GetAllAsync();
        Task<ErrorOr<Updated>> UpdateAsync(Address address);
    }
}