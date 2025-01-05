using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;

namespace Core.Domain.Common.Entities
{
    public class Address : Entity<AddressId>
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
            double longitude)
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
                longitude);
        }

#pragma warning disable CS8618
        protected Address() { }
#pragma warning restore CS8618
    }
}