using Core.Domain.Common.Entities;
using Core.Domain.Common.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    // TODO: [Create async repository functions #27]
    public interface IAddressRepository
    {
        Address? GetById(AddressId id);
        List<Address> All();
        Address Add(Address menu);
        Address Update(Address menu);
        void Delete(AddressId id);
    }
}