namespace Ribbons.Users.Model
{
    public enum CreateUserStatus
    {
        Ok = 0,
        Invalid = 1,
        Duplicate = 2,
        Error = 3,
        UserDomainNotFound = 4
    }
}