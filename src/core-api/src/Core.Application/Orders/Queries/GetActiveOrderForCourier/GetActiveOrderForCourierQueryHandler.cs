using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Orders.Common;
using Core.Domain.Common.Errors;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetActiveOrderForCourier
{
    public class GetActiveOrderForCourierQueryHandler
        : IRequestHandler<GetActiveOrderForCourierQuery, ErrorOr<ActiveOrderForCourierDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserContextService _ctxService;

        public GetActiveOrderForCourierQueryHandler(
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

        public async Task<ErrorOr<ActiveOrderForCourierDTO>> Handle(
            GetActiveOrderForCourierQuery request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();

            var order = await _orderRepository.GetActiveForCourier(userId);

            if (order.IsError)
                return Errors.Order.NoActiveOrder;

            var restaurant = await _restaurantRepository.GetByIdAsync(order.Value.RestaurantId);

            var deliveryAddress = await _addressRepository.GetByIdAsync(order.Value.DeliveryAddressId);

            double? distance;

            if (request.Latitude is null || request.Longitude is null)
                distance = null;
            else
                distance = deliveryAddress.Value.CalculateDistance(
                    (double)request.Latitude,
                    (double)request.Longitude);

            return new ActiveOrderForCourierDTO(
                order.Value,
                restaurant.Value,
                distance,
                deliveryAddress.Value);
        }
    }
}