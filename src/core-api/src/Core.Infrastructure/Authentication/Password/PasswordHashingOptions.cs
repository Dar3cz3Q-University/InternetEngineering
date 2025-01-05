namespace Core.Infrastructure.Authentication.Password
{
    public class PasswordHashingOptions
    {
        public const string SECTION_NAME = "PasswordHashing";
        public int Iterations { get; init; }
        public int MemorySize { get; init; }
        public int Parallelism { get; init; }
        public int SaltSize { get; init; }
        public int HashSize { get; init; }
    }
}