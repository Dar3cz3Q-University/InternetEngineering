﻿using Core.Domain.CategoryAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IRestaurantRepository
    {
        Task<ErrorOr<Created>> AddAsync(Restaurant restaurant);
        Task<ErrorOr<Deleted>> DeleteByIdAsync(RestaurantId id);
        Task<ErrorOr<Restaurant>> GetByIdAsync(RestaurantId id);
        Task<ErrorOr<List<Restaurant>>> GetByIdsAsync(List<RestaurantId> ids);
        Task<ErrorOr<List<Restaurant>>> GetAllAsync();
        Task<ErrorOr<List<Restaurant>>> GetAllFilteredByCategoryAsync(List<CategoryId> categoryIds);
        Task<ErrorOr<Updated>> UpdateAsync(Restaurant restaurant);
    }
}