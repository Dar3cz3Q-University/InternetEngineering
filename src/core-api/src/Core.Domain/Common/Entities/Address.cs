﻿using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;

namespace Core.Domain.Common.Entities
{
    public class Address : Entity<AddressId>, IHasTimestamps
    {
        public string Street { get; private set; }
        public string BuildingNumber { get; private set; }
        public string? ApartmentNumber { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private Address(
            AddressId id,
            string street,
            string buildingNumber,
            string? apartmentNumber,
            string postalCode,
            string city,
            string state,
            string country,
            double latitude,
            double longitude,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            Id = id;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            PostalCode = postalCode;
            City = city;
            State = state;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Address Create(
            string street,
            string buildingNumber,
            string? apartmentNumber,
            string postalCode,
            string city,
            string state,
            string country,
            double latitude,
            double longitude)
        {
            return new(
                AddressId.CreateUnique(),
                street,
                buildingNumber,
                apartmentNumber,
                postalCode,
                city,
                state,
                country,
                latitude,
                longitude,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        protected Address() { }
#pragma warning restore CS8618

        public double CalculateDistance(double lat, double lon)
        {
            const double EarthRadiusKm = 6371.0;

            double dLat = DegreesToRadians(Latitude - lat);
            double dLon = DegreesToRadians(Longitude - lon);

            double lat1Rad = DegreesToRadians(lat);
            double lat2Rad = DegreesToRadians(Latitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}