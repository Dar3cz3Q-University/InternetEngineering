using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly List<Order> _orders = [];
        public Order? GetById(OrderId id)
        {
            return _orders.Find(o => o.Id == id);
        }
        public List<Order> All() => _orders;
        public Order Add(Order order)
        {
            _orders.Add(order);
            return order;
        }
        public Order Update(Order order)
        {
            throw new NotImplementedException();
        }
        public void Delete(OrderId id)
        {
            _orders.Remove(GetById(id));
        }
    }
}