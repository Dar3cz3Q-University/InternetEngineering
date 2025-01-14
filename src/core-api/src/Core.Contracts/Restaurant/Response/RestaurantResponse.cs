﻿using Core.Contracts.Common.Response;

namespace Core.Contracts.Restaurant.Response
{
    public record RestaurantResponse(
        string Id,
        string Name,
        AddressResponse Location,
        string Description,
        ContactInfoResponse ContactInfo,
        OpeningHours OpeningHours,
        bool IsOpen);
}