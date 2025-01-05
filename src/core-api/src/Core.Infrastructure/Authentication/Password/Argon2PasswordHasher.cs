using Core.Application.Common.Interfaces.Services;
using Konscious.Security.Cryptography;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Core.Infrastructure.Authentication.Password
{
    public class Argon2PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHashingOptions _options;

        public Argon2PasswordHasher(IOptions<PasswordHashingOptions> options)
        {
            _options = options.Value;
        }

        public string HashPassword(string password)
        {
            var salt = GenerateSalt(_options.SaltSize);

            using var hasher = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = _options.Parallelism,
                MemorySize = _options.MemorySize,
                Iterations = _options.Iterations
            };

            var hash = hasher.GetBytes(_options.HashSize);

            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var parts = hashedPassword.Split(':');

            if (parts.Length != 2) return false;

            var salt = Convert.FromBase64String(parts[0]);
            var originalHash = Convert.FromBase64String(parts[1]);

            using var hasher = new Argon2id(Encoding.UTF8.GetBytes(providedPassword))
            {
                Salt = salt,
                DegreeOfParallelism = _options.Parallelism,
                MemorySize = _options.MemorySize,
                Iterations = _options.Iterations
            };

            var computedHash = hasher.GetBytes(_options.HashSize);

            return CryptographicOperations.FixedTimeEquals(originalHash, computedHash);
        }

        private static byte[] GenerateSalt(int saltSize)
        {
            var salt = new byte[saltSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }
    }
}