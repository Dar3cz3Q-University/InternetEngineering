using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public sealed class ContactInfo : ValueObject
    {
        public string PhoneNumber { get; }
        public string Email { get; }

        private ContactInfo(
            string phoneNumber,
            string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public static ContactInfo Create(
            string phoneNumber,
            string email)
        {
            return new(phoneNumber, email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNumber;
            yield return Email;
        }
    }
}