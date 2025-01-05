using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MainDbContext _dbContext;

        public OrderRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ErrorOr<Created>> AddAsync(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> DeleteByIdAsync(OrderId id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order is null)
            {
                return Errors.Order.NotFound(id);
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        public async Task<ErrorOr<List<Order>>> GetAllAsync()
        {
            return await _dbContext.Set<Order>().ToListAsync();
        }

        public async Task<ErrorOr<Order>> GetByIdAsync(OrderId id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order is null)
            {
                return Errors.Order.NotFound(id);
            }

            return order;
        }

        public async Task<ErrorOr<Updated>> UpdateAsync(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();

            return Result.Updated;
        }
    }
}