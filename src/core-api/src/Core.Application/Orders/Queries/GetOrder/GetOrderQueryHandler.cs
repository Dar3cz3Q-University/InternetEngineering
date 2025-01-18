using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Orders.Common;
using Core.Application.Restaurants.Common;
using Core.Domain.Common.Errors;
using Core.Domain.OrderAggregate;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler :
        IRequestHandler<GetOrderQuery, ErrorOr<OrderWithDetailsDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _ctxService;

        public GetOrderQueryHandler(
            IOrderRepository orderRepository,
            IRestaurantRepository restaurantRepository,
            IAddressRepository addressRepository,
            IUserRepository userRepository,
            IUserContextService ctxService)
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<OrderWithDetailsDTO>> Handle(
            GetOrderQuery request,
            CancellationToken cancellationToken)
        {
            var orderResult = await _orderRepository.GetByIdAsync(request.OrderId);

            // TODO: Check for more specific error
            if (orderResult.IsError)
                return Errors.Order.NotFound(request.OrderId);

            var order = orderResult.Value;

            if (!IsAuthorized(order))
                return Errors.Authentication.InsufficientPermissions;

            var restaurantResult = await _restaurantRepository.GetByIdAsync(order.RestaurantId);
            var restaurant = restaurantResult.Value;

            var itemIds = order.OrderedItems.Select(i => i.ItemId).ToList();
            var items = restaurant.GetItems(itemIds);

            var itemsDTO = items
                .Select(item =>
                {
                    var orderedItem = order.OrderedItems.FirstOrDefault(i => i.ItemId == item.Id);

                    return new OrderedItemDTO(
                        MenuItem: item,
                        Quantity: orderedItem.Quantity
                    );
                })
                .ToList();

            var address = await _addressRepository.GetByIdAsync(order.DeliveryAddressId);

            User? courier = null;

            if (order.CourierId is not null)
            {
                var courierResult = await _userRepository.GetByIdAsync(order.CourierId);

                courier = courierResult.Value;
            }

            return new OrderWithDetailsDTO(
                order,
                new RestaurantDTO(restaurant, null),
                address.Value,
                itemsDTO,
                courier);
        }

        private bool IsAuthorized(Order order)
        {
            var userRole = _ctxService.GetUserRole();

            if (userRole != Domain.UserAggregate.UserRole.Admin)
            {
                var userId = _ctxService.GetUserId();

                if (order.UserId != userId)
                    return false;
            }

            return true;
        }
    }
}