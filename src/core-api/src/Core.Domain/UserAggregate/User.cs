using Core.Domain.Common.Entities;
using Core.Domain.Common.Models;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>, IHasTimestamps
    {
        private readonly List<Address> _addresses = [];
        public string ImageUrl { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public double MaxSearchDistance { get; private set; }
        public UserRole Role { get; private set; }
        public virtual ICollection<Address> Addresses => _addresses.AsReadOnly();
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private User(
            UserId userId,
            string imageUrl,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string password,
            double maxSearchDistance,
            UserRole role,
            Address address) : base(userId)
        {
            ImageUrl = imageUrl;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            MaxSearchDistance = maxSearchDistance;
            Role = role;
            _addresses.Add(address);
        }

        public static User CreateUnique(
            string imageUrl,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string password,
            double maxSearchDistance,
            UserRole role,
            Address address)
        {
            return new(
                UserId.CreateUnique(),
                imageUrl,
                firstName,
                lastName,
                email,
                phoneNumber,
                password,
                maxSearchDistance,
                role,
                address);
        }

#pragma warning disable CS8618
        protected User() { }
#pragma warning restore CS8618

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public void UpdateMaxSearchDistance(double maxSearchDistance)
        {
            MaxSearchDistance = maxSearchDistance;
        }
    }
}