namespace Ribbons.Users.Model
{
    public enum AuthenticateUserStatus
    {
        Ok = 0,
        Invalid = 1,
        UserNotFound = 2,
        CredentialsInvalid = 3,
        Error = 4
    }
}