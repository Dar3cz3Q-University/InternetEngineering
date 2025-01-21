using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Orders.Common;
using Core.Domain.Common.Errors;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrdersReadyToCollect
{
    public class GetOrdersReadyToCollectQueryHandler
        : IRequestHandler<GetOrdersReadyToCollectQuery, ErrorOr<List<OrderWithAddressesDTO>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserContextService _ctxService;

        public GetOrdersReadyToCollectQueryHandler(
            IOrderRepository orderRepository,
            IRestaurantRepository restaurantRepository,
            IAddressRepository addressRepository,
            IUserContextService ctxService)
        {
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
            _addressRepository = addressRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<List<OrderWithAddressesDTO>>> Handle(
            GetOrdersReadyToCollectQuery request,
            CancellationToken cancellationToken)
        {
            var ordersResult = await _orderRepository.GetAllReadyToCollectAsync();
            var orders = ordersResult.Value;

            var restaurantsIds = orders.Select(o => o.RestaurantId).Distinct().ToList();
            var restaurants = await _restaurantRepository.GetByIdsAsync(restaurantsIds);

            var addressesIds = orders.Select(o => o.DeliveryAddressId).Distinct().ToList();
            var addresses = await _addressRepository.GetByIdsAsync(addressesIds);

            var ordersWithDetails = orders
            .Select(order =>
            {
                var restaurant = restaurants.Value.FirstOrDefault(r => r.Id == order.RestaurantId);

                var deliveryAddress = addresses.Value.FirstOrDefault(a => a.Id == order.DeliveryAddressId);

                double? distance;

                if (request.Latitude is null || request.Longitude is null)
                    distance = null;
                else
                    distance = restaurant.Location.CalculateDistance(
                        (double)request.Latitude,
                        (double)request.Longitude);

                return new OrderWithAddressesDTO(
                    order,
                    new Restaurants.Common.RestaurantDTO(restaurant, distance),
                    deliveryAddress); // TODO: Check if null
            })
            .OrderBy(dto => dto.Restaurant.Distance ?? double.MaxValue)
            .ToList();

            return ordersWithDetails;
        }
    }
}
