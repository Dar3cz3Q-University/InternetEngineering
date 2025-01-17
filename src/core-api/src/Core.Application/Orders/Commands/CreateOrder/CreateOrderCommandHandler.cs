using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Orders.Common;
using Core.Domain.Common.Errors;
using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.Entities;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler :
        IRequestHandler<CreateOrderCommand, ErrorOr<OrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserContextService _ctxService;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IRestaurantRepository restaurantRepository,
            IUserContextService ctxService)
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<OrderDTO>> Handle(
            CreateOrderCommand command,
            CancellationToken cancellationToken)
        {
            UserId id = _ctxService.GetUserId();

            var restaurantResult = await _restaurantRepository.GetByIdAsync(command.RestaurantId);


            if (restaurantResult.IsError)
                throw new ApplicationException("Failed to retrieve restaurant from database.");

            var restaurant = restaurantResult.Value;

            var itemIds = command.ItemsIds.ConvertAll(i => i.ItemId);
            var items = restaurant.GetItems(itemIds);

            if (itemIds.Count != items.Count)
                return Errors.Order.NotFound();

            var itemsWithQuantity = items
                .ConvertAll(item => (
                    MenuItem: item,
                    Quantity: command.ItemsIds.First(i => i.ItemId == item.Id).Quantity
                ));

            var order = Order.Create(
                id,
                command.RestaurantId,
                command.AddressId,
                CalculateOrderValue(itemsWithQuantity),
                command.ItemsIds.ConvertAll(
                    i => OrderedItem.Create(i.ItemId, i.Quantity)));

            var result = await _orderRepository.AddAsync(order);

            // TODO: Check for more specific error
            if (result.IsError)
                throw new ApplicationException("Failed to add order to database.");

            return new OrderDTO(order, restaurant);
        }

        private static Money CalculateOrderValue(List<(MenuItem, uint)> items)
        {
            decimal sum = 0;

            foreach (var item in items)
                sum += item.Item1.Price.Amount * item.Item2;

            return Money.Create(sum, "PLN"); // TODO: Currency from user
        }
    }
}