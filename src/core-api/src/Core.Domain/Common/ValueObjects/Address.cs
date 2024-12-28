using Core.Domain.Common.Models;

namespace Core.Domain.Common.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string PostalCode { get; }

        private Address(
            string street,
            string city,
            string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public static Address Create(
            string street,
            string city,
            string postalCode) 
        {
            return new(street, city, postalCode);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return PostalCode;
        }
    }
}
