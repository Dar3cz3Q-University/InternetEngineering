using Core.Domain.Common.Entities;
using Core.Domain.Common.Models;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>, IHasTimestamps
    {
        private readonly List<Address> _addresses = [];
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private User(
            UserId userId,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string password,
            UserRole role,
            Address address,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;
            _addresses.Add(address);
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User CreateUnique(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string password,
            UserRole role,
            Address address)
        {
            return new(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                phoneNumber,
                password,
                role,
                address,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private User() { }
#pragma warning restore CS8618
    }
}