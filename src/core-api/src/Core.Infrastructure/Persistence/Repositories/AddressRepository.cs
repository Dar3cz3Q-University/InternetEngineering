using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Entities;
using Core.Domain.Common.Errors;
using Core.Domain.Common.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly MainDbContext _dbContext;

        public AddressRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<Created>> AddAsync(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);

            await _dbContext.AddAsync(address);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> DeleteByIdAsync(AddressId id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);

            if (address is null)
                return Errors.Address.NotFound(id);

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        public async Task<ErrorOr<List<Address>>> GetAllAsync()
        {
            return await _dbContext.Set<Address>().ToListAsync();
        }

        public async Task<ErrorOr<Address>> GetByIdAsync(AddressId id)
        {
            var address = await _dbContext.Addresses.FindAsync(id);

            if (address is null)
                return Errors.Address.NotFound(id);

            return address;
        }

        public async Task<ErrorOr<Updated>> UpdateAsync(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);

            _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync();

            return Result.Updated;
        }
    }
}