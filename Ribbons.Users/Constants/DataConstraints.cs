namespace Ribbons.Users.Constants
{
    public static class DataConstraints
    {
        public const int DomainNameMinLength = 3;
        public const int DomainNameMaxLength = 255;
        public const string DomainNamePattern = @"\A[A-Za-z0-9]+(?:[._-][A-Za-z0-9]+)*\z";
        public const int UserNameMinLength = 6;
        public const int UserNameMaxLength = 30;
        public const string UserNamePattern = @"\A[A-Za-z0-9]+(?:[._-][A-Za-z0-9]+)*\z";
        public const int PasswordMinSize = 3;
        public const int PasswordMaxSize = 128;
        public const int DescriptionMaxLength = 255;
    }
}
