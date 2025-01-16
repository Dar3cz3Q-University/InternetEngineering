namespace Core.Application.Common.Config
{
    public class StaticFilesSettings
    {
        public const string SECTION_NAME = "FilesHosting";
        public string BasePrefix { get; init; } = null!;
        public const string RESTAURANTS = "uploads/images/restaurant";
    }
}