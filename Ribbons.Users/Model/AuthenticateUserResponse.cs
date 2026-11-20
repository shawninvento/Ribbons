using Ribbons.Validation;
using System.Collections.Generic;

namespace Ribbons.Users.Model
{
    public sealed class AuthenticateUserResponse : UserManagerResponse<AuthenticateUserStatus>
    {
        public AuthenticateUserResponse(AuthenticateUserStatus status, string message) : base(status, message) { }
        public AuthenticateUserResponse(AuthenticateUserStatus status, string message, IEnumerable<ValidationError> validationErrors) : base(status, message, validationErrors) { }
    }
}