using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    // TODO: [Create async repository functions #27]
    public interface IOrderRepository
    {
        Order? GetById(OrderId id);
        List<Order> All();
        Order Add(Order order);
        Order Update(Order order);
        void Delete(OrderId id);
    }
}