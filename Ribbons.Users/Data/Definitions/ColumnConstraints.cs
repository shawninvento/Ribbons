namespace Ribbons.Users.Data.Definitions
{
    internal static class ColumnConstraints
    {
        public const int UserNameLength = 255;
        public const int DomainNameLength = 255;
        public const int DescriptionLength = 255;
        public const int PasswordSaltLength = 64;
        public const int PasswordHashLength = 64;
        public const int UserSessionIdLength = 64;
    }
}