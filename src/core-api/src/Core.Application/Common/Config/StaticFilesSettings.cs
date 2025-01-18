namespace Core.Application.Common.Config
{
    public class StaticFilesSettings
    {
        public const string SECTION_NAME = "FilesHosting";
        public string BasePrefix { get; init; } = null!;
        public const string RESTAURANTS = "uploads/images/restaurant";
        public const string USERS = "uploads/images/user";
        public const string CATEGORIES = "uploads/images/categories";
        public const string MENU_ITEMS = "uploads/images/menu_items";
    }
}