using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Orders.Common;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler :
        IRequestHandler<GetOrdersQuery, ErrorOr<List<OrderDTO>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        private readonly IUserContextService _ctxService;

        public GetOrdersQueryHandler(
            IOrderRepository orderRepository,
            IRestaurantRepository restaurantRepository,
            IUserContextService ctxService)
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<List<OrderDTO>>> Handle(
            GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var userRole = _ctxService.GetUserRole();

            var orders = userRole == Domain.UserAggregate.UserRole.Admin ? await _orderRepository.GetAllAsync() : await _orderRepository.GetForUserIdAsync(_ctxService.GetUserId());

            if (orders.Value.Count == 0)
                return new List<OrderDTO>();

            var restaurantsIds = orders.Value.Select(o => o.RestaurantId).Distinct().ToList();

            var restaurants = await _restaurantRepository.GetByIdsAsync(restaurantsIds);

            var ordersWithRestaurants = orders.Value
            .Select(order =>
            {
                var restaurant = restaurants.Value.FirstOrDefault(r => r.Id == order.RestaurantId);
                return new OrderDTO(order, restaurant); // TODO: Check if null
            })
            .ToList();

            return ordersWithRestaurants;
        }
    }
}