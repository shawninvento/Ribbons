using Ribbons.Validation;
using System.Collections.Generic;

namespace Ribbons.Users.Model
{
    public sealed class CreateUserResponse : UserManagerResponse<CreateUserStatus>
    {
        public CreateUserResponse(CreateUserStatus status, string message) : base(status, message) { }
        public CreateUserResponse(CreateUserStatus status, string message, IEnumerable<ValidationError> validationErrors) : base(status, message, validationErrors) { }
    }
}