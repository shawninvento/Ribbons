using Ribbons.Validation;
using System.Collections.Generic;

namespace Ribbons.Users.Model
{
    public sealed class CreateUserDomainResponse : UserManagerResponse<CreateUserDomainStatus>
    {
        public CreateUserDomainResponse(CreateUserDomainStatus status, string message) : base(status, message) { }
        public CreateUserDomainResponse(CreateUserDomainStatus status, string message, IEnumerable<ValidationError> validationErrors) : base(status, message, validationErrors) { }
    }
}