using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IOrderRepository
    {
        Task<ErrorOr<Created>> AddAsync(Order order);
        Task<ErrorOr<Deleted>> DeleteByIdAsync(OrderId id);
        Task<ErrorOr<Order>> GetByIdAsync(OrderId id);
        Task<ErrorOr<List<Order>>> GetAllAsync();
        Task<ErrorOr<Updated>> UpdateAsync(Order order);
    }
}