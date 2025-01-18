using Core.Application.Common.Dtos;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.Entities;
using Mapster;

namespace Core.Application.Common.Mapping
{
    public class OrderCreatedEventMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Order, double), OrderCreatedMessageDTO>()
                .Map(dest => dest.OrderId, src => src.Item1.Id.Value)
                .Map(dest => dest.Distance, src => src.Item2)
                .Map(dest => dest.Items, src => src.Item1.OrderedItems.Adapt<List<OrderedItemDTO>>());

            config.NewConfig<OrderedItem, OrderedItemDTO>()
                .Map(dest => dest.ItemId, src => src.ItemId.Value);
        }
    }
}