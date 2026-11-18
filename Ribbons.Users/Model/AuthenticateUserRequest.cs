using Ribbons.Users.Constants;
using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Model
{
    public sealed class AuthenticateUserRequest
    {
        [StringLength(DataConstraints.DomainNameMaxLength)]
        [RegularExpression(DataConstraints.DomainNamePattern)]
        public string DomainName { get; set; }

        [StringLength(DataConstraints.UserNameMaxLength, MinimumLength = DataConstraints.UserNameMinLength)]
        [RegularExpression(DataConstraints.UserNamePattern)]
        public string UserName { get; set; }

        [StringLength(DataConstraints.PasswordMaxSize, MinimumLength = DataConstraints.PasswordMinSize)]
        public string Password { get; set; }
    }
}